namespace TengGuang.VedioScreen.UI
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbRecordLocation = new System.Windows.Forms.GroupBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.saveFile = new TengGuang.VedioScreen.UI.Control.SaveFile();
            this.gbProfile = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.lblProfileType = new System.Windows.Forms.Label();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbAudioVideo = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbOnlyVideo = new System.Windows.Forms.RadioButton();
            this.rbOnlyAudio = new System.Windows.Forms.RadioButton();
            this.gbClipArea = new System.Windows.Forms.GroupBox();
            this.clipScreen = new TengGuang.VedioScreen.UI.Control.ClipScreen();
            this.findWindow = new TengGuang.VedioScreen.UI.Control.FindWindow();
            this.lblOriPointY = new System.Windows.Forms.Label();
            this.tbOriPointY = new System.Windows.Forms.TextBox();
            this.tbOriPointX = new System.Windows.Forms.TextBox();
            this.tbAreaHeight = new System.Windows.Forms.TextBox();
            this.lblAreaHeight = new System.Windows.Forms.Label();
            this.tbAreaWidth = new System.Windows.Forms.TextBox();
            this.lblAreaWidth = new System.Windows.Forms.Label();
            this.lblOriPointX = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbWindow = new System.Windows.Forms.RadioButton();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.mMainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miHotKey = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stsmShowMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.stmsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.stmsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.gbRecordLocation.SuspendLayout();
            this.gbProfile.SuspendLayout();
            this.gbAudioVideo.SuspendLayout();
            this.gbClipArea.SuspendLayout();
            this.mMainMenu.SuspendLayout();
            this.cmsTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecordLocation
            // 
            this.gbRecordLocation.Controls.Add(this.btnPlay);
            this.gbRecordLocation.Controls.Add(this.saveFile);
            this.gbRecordLocation.Location = new System.Drawing.Point(184, 217);
            this.gbRecordLocation.Name = "gbRecordLocation";
            this.gbRecordLocation.Size = new System.Drawing.Size(421, 91);
            this.gbRecordLocation.TabIndex = 1;
            this.gbRecordLocation.TabStop = false;
            this.gbRecordLocation.Text = "录制位置";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(5, 57);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(99, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "播放录制内容";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(4, 24);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(391, 21);
            this.saveFile.TabIndex = 1;
            // 
            // gbProfile
            // 
            this.gbProfile.Controls.Add(this.tbDescription);
            this.gbProfile.Controls.Add(this.lblProfileType);
            this.gbProfile.Controls.Add(this.cbProfiles);
            this.gbProfile.Location = new System.Drawing.Point(184, 24);
            this.gbProfile.Name = "gbProfile";
            this.gbProfile.Size = new System.Drawing.Size(421, 179);
            this.gbProfile.TabIndex = 3;
            this.gbProfile.TabStop = false;
            this.gbProfile.Text = "压缩格式";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(5, 53);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(390, 118);
            this.tbDescription.TabIndex = 2;
            this.tbDescription.Text = "";
            // 
            // lblProfileType
            // 
            this.lblProfileType.AutoSize = true;
            this.lblProfileType.Location = new System.Drawing.Point(3, 24);
            this.lblProfileType.Name = "lblProfileType";
            this.lblProfileType.Size = new System.Drawing.Size(53, 12);
            this.lblProfileType.TabIndex = 1;
            this.lblProfileType.Text = "选择格式";
            // 
            // cbProfiles
            // 
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(64, 22);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(331, 20);
            this.cbProfiles.TabIndex = 0;
            this.cbProfiles.SelectedIndexChanged += new System.EventHandler(this.cbProfiles_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(184, 322);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始录制";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(265, 322);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "暂停录制";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(346, 322);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "停止录制";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gbAudioVideo
            // 
            this.gbAudioVideo.Controls.Add(this.rbBoth);
            this.gbAudioVideo.Controls.Add(this.rbOnlyVideo);
            this.gbAudioVideo.Controls.Add(this.rbOnlyAudio);
            this.gbAudioVideo.Location = new System.Drawing.Point(3, 217);
            this.gbAudioVideo.Name = "gbAudioVideo";
            this.gbAudioVideo.Size = new System.Drawing.Size(175, 128);
            this.gbAudioVideo.TabIndex = 7;
            this.gbAudioVideo.TabStop = false;
            this.gbAudioVideo.Text = "音/视频选项";
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Checked = true;
            this.rbBoth.Location = new System.Drawing.Point(7, 96);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(65, 16);
            this.rbBoth.TabIndex = 8;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "音/视频";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbOnlyVideo
            // 
            this.rbOnlyVideo.AutoSize = true;
            this.rbOnlyVideo.Location = new System.Drawing.Point(7, 61);
            this.rbOnlyVideo.Name = "rbOnlyVideo";
            this.rbOnlyVideo.Size = new System.Drawing.Size(59, 16);
            this.rbOnlyVideo.TabIndex = 7;
            this.rbOnlyVideo.Text = "仅视频";
            this.rbOnlyVideo.UseVisualStyleBackColor = true;
            // 
            // rbOnlyAudio
            // 
            this.rbOnlyAudio.AutoSize = true;
            this.rbOnlyAudio.Location = new System.Drawing.Point(7, 28);
            this.rbOnlyAudio.Name = "rbOnlyAudio";
            this.rbOnlyAudio.Size = new System.Drawing.Size(59, 16);
            this.rbOnlyAudio.TabIndex = 6;
            this.rbOnlyAudio.Text = "仅音频";
            this.rbOnlyAudio.UseVisualStyleBackColor = true;
            // 
            // gbClipArea
            // 
            this.gbClipArea.Controls.Add(this.clipScreen);
            this.gbClipArea.Controls.Add(this.findWindow);
            this.gbClipArea.Controls.Add(this.lblOriPointY);
            this.gbClipArea.Controls.Add(this.tbOriPointY);
            this.gbClipArea.Controls.Add(this.tbOriPointX);
            this.gbClipArea.Controls.Add(this.tbAreaHeight);
            this.gbClipArea.Controls.Add(this.lblAreaHeight);
            this.gbClipArea.Controls.Add(this.tbAreaWidth);
            this.gbClipArea.Controls.Add(this.lblAreaWidth);
            this.gbClipArea.Controls.Add(this.lblOriPointX);
            this.gbClipArea.Controls.Add(this.rbAll);
            this.gbClipArea.Controls.Add(this.rbWindow);
            this.gbClipArea.Controls.Add(this.rbSelect);
            this.gbClipArea.Location = new System.Drawing.Point(7, 24);
            this.gbClipArea.Name = "gbClipArea";
            this.gbClipArea.Size = new System.Drawing.Size(171, 179);
            this.gbClipArea.TabIndex = 8;
            this.gbClipArea.TabStop = false;
            this.gbClipArea.Text = "裁减区域";
            // 
            // clipScreen
            // 
            this.clipScreen.BackgroundImage = global::TengGuang.VedioScreen.UI.Properties.Resources.Clip;
            this.clipScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clipScreen.Location = new System.Drawing.Point(78, 23);
            this.clipScreen.Name = "clipScreen";
            this.clipScreen.Size = new System.Drawing.Size(16, 16);
            this.clipScreen.TabIndex = 11;
            this.clipScreen.Visible = false;
            this.clipScreen.CaptureEnd += new TengGuang.VedioScreen.UI.Control.ClipScreen.CaptureEndProto(this.clipScreen_CaptureEnd);
            // 
            // findWindow
            // 
            this.findWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.findWindow.Location = new System.Drawing.Point(78, 49);
            this.findWindow.Name = "findWindow";
            this.findWindow.Size = new System.Drawing.Size(16, 16);
            this.findWindow.TabIndex = 9;
            this.findWindow.CaptureBegin += new TengGuang.VedioScreen.UI.Control.FindWindow.CaptureBeginProto(this.findWindow_CaptureBegin);
            this.findWindow.CaptureEnd += new TengGuang.VedioScreen.UI.Control.FindWindow.CaptureEndProto(this.findWindow_CaptureEnd);
            // 
            // lblOriPointY
            // 
            this.lblOriPointY.AutoSize = true;
            this.lblOriPointY.Location = new System.Drawing.Point(84, 112);
            this.lblOriPointY.Name = "lblOriPointY";
            this.lblOriPointY.Size = new System.Drawing.Size(11, 12);
            this.lblOriPointY.TabIndex = 10;
            this.lblOriPointY.Text = "Y";
            // 
            // tbOriPointY
            // 
            this.tbOriPointY.Location = new System.Drawing.Point(115, 109);
            this.tbOriPointY.Name = "tbOriPointY";
            this.tbOriPointY.Size = new System.Drawing.Size(41, 21);
            this.tbOriPointY.TabIndex = 9;
            // 
            // tbOriPointX
            // 
            this.tbOriPointX.Location = new System.Drawing.Point(37, 109);
            this.tbOriPointX.Name = "tbOriPointX";
            this.tbOriPointX.Size = new System.Drawing.Size(41, 21);
            this.tbOriPointX.TabIndex = 8;
            // 
            // tbAreaHeight
            // 
            this.tbAreaHeight.Location = new System.Drawing.Point(115, 144);
            this.tbAreaHeight.Name = "tbAreaHeight";
            this.tbAreaHeight.Size = new System.Drawing.Size(41, 21);
            this.tbAreaHeight.TabIndex = 7;
            // 
            // lblAreaHeight
            // 
            this.lblAreaHeight.AutoSize = true;
            this.lblAreaHeight.Location = new System.Drawing.Point(83, 148);
            this.lblAreaHeight.Name = "lblAreaHeight";
            this.lblAreaHeight.Size = new System.Drawing.Size(29, 12);
            this.lblAreaHeight.TabIndex = 6;
            this.lblAreaHeight.Text = "高度";
            // 
            // tbAreaWidth
            // 
            this.tbAreaWidth.Location = new System.Drawing.Point(38, 144);
            this.tbAreaWidth.Name = "tbAreaWidth";
            this.tbAreaWidth.Size = new System.Drawing.Size(41, 21);
            this.tbAreaWidth.TabIndex = 5;
            // 
            // lblAreaWidth
            // 
            this.lblAreaWidth.AutoSize = true;
            this.lblAreaWidth.Location = new System.Drawing.Point(7, 148);
            this.lblAreaWidth.Name = "lblAreaWidth";
            this.lblAreaWidth.Size = new System.Drawing.Size(29, 12);
            this.lblAreaWidth.TabIndex = 4;
            this.lblAreaWidth.Text = "宽度";
            // 
            // lblOriPointX
            // 
            this.lblOriPointX.AutoSize = true;
            this.lblOriPointX.Location = new System.Drawing.Point(7, 113);
            this.lblOriPointX.Name = "lblOriPointX";
            this.lblOriPointX.Size = new System.Drawing.Size(11, 12);
            this.lblOriPointX.TabIndex = 3;
            this.lblOriPointX.Text = "X";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(7, 80);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(59, 16);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全屏幕";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.Click += new System.EventHandler(this.rbAll_Click);
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbWindow
            // 
            this.rbWindow.AutoSize = true;
            this.rbWindow.Location = new System.Drawing.Point(7, 50);
            this.rbWindow.Name = "rbWindow";
            this.rbWindow.Size = new System.Drawing.Size(71, 16);
            this.rbWindow.TabIndex = 1;
            this.rbWindow.Text = "指定窗口";
            this.rbWindow.UseVisualStyleBackColor = true;
            this.rbWindow.Click += new System.EventHandler(this.rbWindow_Click);
            // 
            // rbSelect
            // 
            this.rbSelect.AutoSize = true;
            this.rbSelect.Location = new System.Drawing.Point(7, 22);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Size = new System.Drawing.Size(71, 16);
            this.rbSelect.TabIndex = 0;
            this.rbSelect.Text = "手动选择";
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.Click += new System.EventHandler(this.rbSelect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mMainMenu
            // 
            this.mMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miHelp});
            this.mMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mMainMenu.Name = "mMainMenu";
            this.mMainMenu.Size = new System.Drawing.Size(611, 24);
            this.mMainMenu.TabIndex = 10;
            this.mMainMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(59, 20);
            this.miFile.Text = "文件(&F)";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(152, 22);
            this.miExit.Text = "退出(&E)";
            this.miExit.Click += new System.EventHandler(this.eventExitApplication);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout,
            this.miHotKey});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(59, 20);
            this.miHelp.Text = "帮助(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(136, 22);
            this.miAbout.Text = "关于(&A)";
            this.miAbout.Click += new System.EventHandler(this.eventShowAboutForm);
            // 
            // miHotKey
            // 
            this.miHotKey.Name = "miHotKey";
            this.miHotKey.Size = new System.Drawing.Size(136, 22);
            this.miHotKey.Text = "热键定义(&H)";
            this.miHotKey.Click += new System.EventHandler(this.miHotKey_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsTrayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "腾光录屏";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.eventShowWindow);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsmShowMainWindow,
            this.stmsAbout,
            this.stmsExit});
            this.cmsTrayMenu.Name = "cmsTrayMenu";
            this.cmsTrayMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // stsmShowMainWindow
            // 
            this.stsmShowMainWindow.Name = "stsmShowMainWindow";
            this.stsmShowMainWindow.Size = new System.Drawing.Size(152, 22);
            this.stsmShowMainWindow.Text = "显示主窗体(&S)";
            this.stsmShowMainWindow.Click += new System.EventHandler(this.eventShowWindow);
            // 
            // stmsAbout
            // 
            this.stmsAbout.Name = "stmsAbout";
            this.stmsAbout.Size = new System.Drawing.Size(152, 22);
            this.stmsAbout.Text = "关于(&A)";
            this.stmsAbout.Click += new System.EventHandler(this.eventShowAboutForm);
            // 
            // stmsExit
            // 
            this.stmsExit.Name = "stmsExit";
            this.stmsExit.Size = new System.Drawing.Size(152, 22);
            this.stmsExit.Text = "退出(&E)";
            this.stmsExit.Click += new System.EventHandler(this.eventExitApplication);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbClipArea);
            this.Controls.Add(this.gbAudioVideo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbProfile);
            this.Controls.Add(this.gbRecordLocation);
            this.Controls.Add(this.mMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.gbRecordLocation.ResumeLayout(false);
            this.gbProfile.ResumeLayout(false);
            this.gbProfile.PerformLayout();
            this.gbAudioVideo.ResumeLayout(false);
            this.gbAudioVideo.PerformLayout();
            this.gbClipArea.ResumeLayout(false);
            this.gbClipArea.PerformLayout();
            this.mMainMenu.ResumeLayout(false);
            this.mMainMenu.PerformLayout();
            this.cmsTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRecordLocation;
        private TengGuang.VedioScreen.UI.Control.SaveFile saveFile;
        private System.Windows.Forms.GroupBox gbProfile;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gbAudioVideo;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbOnlyVideo;
        private System.Windows.Forms.RadioButton rbOnlyAudio;
        private System.Windows.Forms.GroupBox gbClipArea;
        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbWindow;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Label lblProfileType;
        private System.Windows.Forms.Label lblOriPointY;
        private System.Windows.Forms.TextBox tbOriPointY;
        private System.Windows.Forms.TextBox tbOriPointX;
        private System.Windows.Forms.TextBox tbAreaHeight;
        private System.Windows.Forms.Label lblAreaHeight;
        private System.Windows.Forms.TextBox tbAreaWidth;
        private System.Windows.Forms.Label lblAreaWidth;
        private System.Windows.Forms.Label lblOriPointX;
        private TengGuang.VedioScreen.UI.Control.FindWindow findWindow;
        private TengGuang.VedioScreen.UI.Control.ClipScreen clipScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip mMainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miHotKey;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem stsmShowMainWindow;
        private System.Windows.Forms.ToolStripMenuItem stmsAbout;
        private System.Windows.Forms.ToolStripMenuItem stmsExit;

    }
}

