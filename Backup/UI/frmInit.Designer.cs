namespace TengGuang.VedioScreen.UI
{
    partial class frmInit
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.pbRegister = new System.Windows.Forms.ProgressBar();
            this.lblDllName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrompt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPrompt.Location = new System.Drawing.Point(15, 12);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(155, 12);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "第一次启动,正在初始化组件";
            // 
            // pbRegister
            // 
            this.pbRegister.Location = new System.Drawing.Point(15, 48);
            this.pbRegister.Name = "pbRegister";
            this.pbRegister.Size = new System.Drawing.Size(382, 28);
            this.pbRegister.TabIndex = 1;
            // 
            // lblDllName
            // 
            this.lblDllName.AutoSize = true;
            this.lblDllName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDllName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDllName.Location = new System.Drawing.Point(172, 12);
            this.lblDllName.Name = "lblDllName";
            this.lblDllName.Size = new System.Drawing.Size(41, 12);
            this.lblDllName.TabIndex = 2;
            this.lblDllName.Text = "label1";
            // 
            // frmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TengGuang.VedioScreen.UI.Properties.Resources.ProcessBack;
            this.ClientSize = new System.Drawing.Size(417, 93);
            this.Controls.Add(this.lblDllName);
            this.Controls.Add(this.pbRegister);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInit";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.frmInit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.ProgressBar pbRegister;
        private System.Windows.Forms.Label lblDllName;
    }
}