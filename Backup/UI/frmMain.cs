using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TengGuang.VedioScreen.Core;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace TengGuang.VedioScreen.UI
{
    /// <summary>
    /// 主窗体文件
    /// </summary>
    public partial class frmMain : Form
    {
        [DllImport("user32.dll", EntryPoint = "SetDoubleClickTime")]
        internal extern static int SetDoubleClickTime(int wCount);
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        internal extern static int GetDoubleClickTime();

        // 注册热键API
        [DllImport("user32")]
        public static extern bool RegisterHotKey(IntPtr hWnd,int id,uint control,Keys vk );
        [DllImport("user32")] 
        public static extern bool UnregisterHotKey(IntPtr hWnd,    int id);
        const int WM_HOTKEY = 0x0312;
        const int MOD_ALT = 0x0001;
        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int MOD_WIN = 0x0008;

        private Thread iconRunState = null; // 后台管理拖盘图标闪动的线程
        private Hashtable profileInfos = null;  // 压缩方式信息集
        private Recordor recorder; // 录制控制器(Recordor)实例

        private enum RecordState
        {
            /// <summary>
            /// 录制中
            /// </summary>
            Run,
            /// <summary>
            /// 暂停
            /// </summary>
            Pause,
            /// <summary>
            /// 停止
            /// </summary>
            Stop
        }

        private RecordState currentState =  RecordState.Stop; // 当前的录制状态,默认在停止状态

        public frmMain()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            // 假如是热键消息执行相关处理，否则采用默认处理
            if (m.Msg == WM_HOTKEY)
            {
                // 假如为 触发 开始录制 热键，执行开始录制，假如触发 结束录制 热键，结束录制
                if (m.WParam.ToString().Equals("666")) // 开始录制 F11
                {
                    if (BeginRecord())
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
                if (m.WParam.ToString().Equals("888")) // 结束录制 F12
                {
                    TerminateRecord();
                    Show();
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 开始注册热键
            // 开始录制热键
            RegisterHotKey(this.Handle, 666, 0, Keys.F1);
            // 结束录制热键
            RegisterHotKey(this.Handle, 888, 0, Keys.F2); 

            Start:
           
            try
            {
                // 使用 WMVEncoder 编码
                recorder = new Recordor(new WMVEncoder());
            }
            catch
            {
                // 初始化COM组件信息
                InitCOM();

                goto Start;
            }

            // 设置标题 使用的是资源文件 
            this.Text = Properties.Resources.SoftName;

            // 设置只能存为WMV文件
            saveFile.Filter = "WMV文件(*.wmv)|*.wmv";

            /// Rewrite by 乔伟 at Rewrite Date:2008-11-25
            /// START1:
            /*
            // 初始化压缩选项
            InitProfile();
            */
            // 原来是在这里直接调用InitProfile()进行压缩格式的初始化，但导致双击运行后显示界面时过于缓慢，故将此提入一个新线程去执行
            Thread initProfileThread = new Thread(InitProfileThread);
            initProfileThread.IsBackground = true;
            initProfileThread.Start();

            /// END1
            // 初始化录制的裁减区域
            InitClipArea();

            // 设置控制按钮初始状态
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnPlay.Enabled = false;

            // findWindow控件初始的时候是隐藏的
            findWindow.Visible = false;

            // 拖盘图标处理
            notifyIcon.Visible = true;
        }
        
        /// <summary>
        /// 初始化压缩格式的线程
        /// </summary>
        /// <param name="obj"></param>
        public void InitProfileThread(object obj)
        {
            // 延迟一百毫秒，使界面运行时的效果更好
            Thread.Sleep(100);
            // 直接调用原来写的方法
            InitProfile();   
        }
        
        /// <summary>
        /// 初始化压缩选项
        /// </summary>
        private void InitProfile()
        {
            profileInfos = recorder.Encoder.GetProfileInfos();

            // 循环读取压缩格式 名称
            foreach (string profileName in profileInfos.Keys)
            {
                // 只列出屏幕录制所用的压缩格式即可
                //if (profileName.IndexOf("屏幕视频") >= 0)
                {
                    cbProfiles.Items.Add(profileName);
                }
            }

            // 设置默认值
            cbProfiles.SelectedIndex = 21;
        }

        public void InitCOM()
        {
            // 以模式对话框方式  显示 frmInit
            frmInit fi = new frmInit();
            fi.ShowDialog();

            /******本来准备使用启动一个进程，并等待他结束来注册COM组件 现改用管道方式,提到frmInit里去完成 by qw *****
             * // 获取当前应用程序的路径
            string path = Application.StartupPath;

            // 等待窗口完成加载
            p.WaitForInputIdle();

            // 等待进程结束 
            p.WaitForExit();
            * *******************************************************************************************************/
        }

        /// <summary>
        /// 初始化窗口区域
        /// </summary>
        private void InitClipArea()
        {
            tbOriPointX.Text = "0";
            tbOriPointY.Text = "0";
            tbAreaWidth.Text = SystemInformation.PrimaryMonitorSize.Width.ToString();
            tbAreaHeight.Text = SystemInformation.PrimaryMonitorSize.Height.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            BeginRecord();
        }

        private bool  BeginRecord()
        {
            recorder = new Recordor(new WMVEncoder());

            // 假如已经选择文件保存路径
            if (saveFile.FilePath != string.Empty)
            {
                try
                {
                    // 假如当前不处于运行状态
                    if (currentState != RecordState.Run)
                    {
                        // 假如压缩方式已经选定
                        if (cbProfiles.Text != string.Empty)
                        {
                            // 初始录制区域 此处设为全屏，本例子不进行局部录制的处理
                            ScreenArea area;
                            area.X = int.Parse(tbOriPointX.Text); // 左上角坐标X值
                            area.Y = int.Parse(tbOriPointY.Text); // 左上角坐标Y值 
                            area.Weight = int.Parse(tbAreaWidth.Text); // 宽度
                            area.Height = int.Parse(tbAreaHeight.Text); // 高度

                            // 初始媒体信息
                            MediaInfo mediaInfo = new MediaInfo();
                            mediaInfo.SavePath = saveFile.FilePath;
                            mediaInfo.ProfileName = cbProfiles.Text;
                            if (rbBoth.Checked)
                            {
                                mediaInfo.AudioVedio = AudioVedioType.Both;
                            }
                            if (rbOnlyAudio.Checked)
                            {
                                mediaInfo.AudioVedio = AudioVedioType.AudioOnly;
                            }
                            if (rbOnlyVideo.Checked)
                            {
                                mediaInfo.AudioVedio = AudioVedioType.VedioOnly;
                            }

                            try
                            {
                                recorder.Start(mediaInfo, area);

                                // 将当前状态设为录制中。
                                this.currentState = RecordState.Run;

                                // 设置按钮状态
                                btnStart.Enabled = false;
                                btnPause.Enabled = true;
                                btnStop.Enabled = true;
                                btnPlay.Enabled = false;
                            }
                            catch (Exception ce)
                            {
                                this.currentState = RecordState.Stop;

                                MessageBox.Show(ce.Message);

                                recorder.Stop();

                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择压缩方式");

                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("正在录制中");

                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请指定保存的位置");

                return false;
            }

            // 启动一个线程 管理拖盘图标的状态 闪动
            if (iconRunState == null)
            {
                iconRunState = new Thread(IconRunStateThread);
                // 设置为后台线程，保证，程序退出时，即使出错了，也会退出。
                iconRunState.IsBackground = true;
                iconRunState.Start();
            }
            else
            {
                iconRunState.Resume();
            }

            return true;
        }

        /// <summary>
        ///  管理图标状态的线程
        /// </summary>
        /// <param name="obj"></param>
        public void IconRunStateThread(object obj)
        {
            while (1 == 1)
            {
                if (this.currentState == RecordState.Run)  // 假如录制过程中则闪动图标
                {
                    notifyIcon.Icon = Properties.Resources.LogoRunning;

                    Thread.Sleep(300);

                    notifyIcon.Icon = Properties.Resources.Logo; 
                    
                    Thread.Sleep(300);

                    continue;
                }
                else if (this.currentState == RecordState.Pause) // 假如暂停 将图标 设 为 LOGO
                {
                    if (notifyIcon.Icon == Properties.Resources.LogoRunning)
                    {
                        notifyIcon.Icon = Properties.Resources.Logo;
                    }
                }
                else // 假如停止录制 则 挂起此线程
                {
                    Thread.CurrentThread.Suspend();
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // 假如处于运行状态
            if (this.currentState == RecordState.Run)
            {
                recorder.Pause();
                this.currentState = RecordState.Pause;

                // 设置按钮状态
                btnPause.Enabled = false;
                btnStop.Enabled = true;
                btnStart.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            TerminateRecord();
        }

        private void TerminateRecord()
        {
            if (this.currentState == RecordState.Run || this.currentState == RecordState.Pause)
            {
                recorder.Stop();

                this.currentState = RecordState.Stop;

                // 设置按钮状态
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                btnPlay.Enabled = true;

                // 拖盘图标通知一声
                notifyIcon.BalloonTipText = "腾光录屏:录制已经完成";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Process p = new Process();

            p.StartInfo.FileName = saveFile.FilePath;

            p.Start();
        }

        private void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 显示压缩方式的相关信息
            tbDescription.Text = profileInfos[cbProfiles.Text].ToString();
        }

        private void findWindow_CaptureBegin()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void findWindow_CaptureEnd(Rectangle rect)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            tbOriPointX.Text = rect.X.ToString();
            tbOriPointY.Text = rect.Y.ToString();
            tbAreaWidth.Text = rect.Width.ToString();
            tbAreaHeight.Text = rect.Height.ToString();
        }

        private void rbSelect_Click(object sender, EventArgs e)
        {
            findWindow.Visible = false;

            clipScreen.BeginCapture();
        }

        private void rbWindow_Click(object sender, EventArgs e)
        {
            findWindow.Visible = true;
        }

        private void rbAll_Click(object sender, EventArgs e)
        {
            findWindow.Visible = false;
        }

        private void clipScreen_CaptureEnd(Rectangle rect)
        {
            tbOriPointX.Text = rect.X.ToString();
            tbOriPointY.Text = rect.Y.ToString();
            tbAreaWidth.Text = rect.Width.ToString();
            tbAreaHeight.Text = rect.Height.ToString();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey(this.Handle, 666);
            UnregisterHotKey(this.Handle, 888);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetDoubleClickTime().ToString());
        }

        private void findWindow_Load(object sender, EventArgs e)
        {
        }

        private void miHotKey_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\r\nF1 开始录制 \r\nF2 停止录制", "热键定义");
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.InitClipArea();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void eventShowWindow(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void eventShowAboutForm(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.Show();
        }

        private void eventExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}