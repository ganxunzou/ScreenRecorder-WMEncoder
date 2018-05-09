using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TengGuang.VedioScreen.UI
{
    public partial class frmInit : Form
    {
        const int SWP_NOSIZE = 1;  // 忽略 cx,cy 设置，保持窗口原大小 
        const int SWP_NOMOVE = 2;  // 忽略 x,y 设置，保持窗口原位置
        const int HWND_TOPMOST = -1; // 所有窗口的上层
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int xc, int cy, uint uFlags);

        public frmInit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据图片创建不规则窗体
        /// </summary>
        /// <param name="Picture">图象</param>
        /// <param name="TransparentColor">透明色</param>
        /// <returns>Region对象</returns>
        public static Region BmpRgn(Bitmap picture)
        {
            Color transparentColor = picture.GetPixel(0, 0); // 以图片的第一个象素的颜色为透明色

            int nWidth = picture.Width;
            int nHeight = picture.Height;
            Region rgn = new Region();
            rgn.MakeEmpty();
            bool isTransRgn; // 前一个点是否在透明区
            Color curColor; // 当前点的颜色
            Rectangle curRect = new Rectangle();
            curRect.Height = 1;
            int x = 0, y = 0;

            // 逐像素扫描这个图片，找出非透明色部分区域并合并起来。
            for (y = 0; y < nHeight; ++y)
            {
                isTransRgn = true;
                for (x = 0; x < nWidth; ++x)
                {
                    curColor = picture.GetPixel(x, y);
                    if (curColor == transparentColor || x == nWidth - 1) // 如果遇到透明色或行尾
                    {
                        if (isTransRgn == false) // 退出有效区
                        {
                            curRect.Width = x - curRect.X;
                            rgn.Union(curRect);
                        }
                    }
                    else // 非透明色
                    {
                        if (isTransRgn == true) // 进入有效区
                        {
                            curRect.X = x;
                            curRect.Y = y;
                        }
                    } // if curColor
                    isTransRgn = curColor == transparentColor;
                } // for x
            } // for y
            return rgn;
        }

        private void frmInit_Load(object sender, EventArgs e)
        {
            // 设置成顶层窗口
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);

            this.Text = "初始化组件";
            this.Region = BmpRgn(Properties.Resources.ProcessBack);
            // 设置进度条
            pbRegister.Maximum = 11;
            pbRegister.Step = 1;

            // 启动新线程进行后台处理，防止界面无法重画
            System.Threading.Thread t = new System.Threading.Thread(SetProcessThread);
            t.Start();
            //timer.Enabled = true;
        }

        private void SetProcessThread()
        {
            // 创建一个新的进程启动信息对象并赋初值
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;
            pInfo.FileName = "cmd.exe";
            pInfo.RedirectStandardError = true;
            pInfo.RedirectStandardInput = true;
            pInfo.RedirectStandardOutput = true;

            // 启动进程
            Process p = Process.Start(pInfo);

            // 使用输入管道向目标进程输入信息
            p.StandardInput.WriteLine("@echo off");
            p.StandardInput.WriteLine("cd Encoder");
            p.StandardInput.WriteLine("reg.bat");
            p.StandardInput.WriteLine("exit");

            // 循环读取目标进程(CMD.exe)返回的信息
            while (!p.StandardOutput.EndOfStream)
            {
                string outputString = p.StandardOutput.ReadLine();

                // 假如返回行信息 包含 注册成功 使进度加 1
                if (outputString.IndexOf("注册成功") > 0)
                {
                    try
                    {
                        lblDllName.Text = outputString.Replace("注册成功","");
                        pbRegister.Value += 1;
                        pbRegister.Refresh();
                    }
                    catch
                    {
                    }
                }
            }

            // this.Close();
        }
    }
}