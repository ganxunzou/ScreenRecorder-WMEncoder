namespace TengGuang.VedioScreen.UI
{
    partial class frmAbout
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
            this.pbCompanyLogo = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblProduce = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCompanyLogo
            // 
            this.pbCompanyLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCompanyLogo.Image = global::TengGuang.VedioScreen.UI.Properties.Resources.TengGuangLogo;
            this.pbCompanyLogo.Location = new System.Drawing.Point(9, 6);
            this.pbCompanyLogo.Name = "pbCompanyLogo";
            this.pbCompanyLogo.Size = new System.Drawing.Size(202, 85);
            this.pbCompanyLogo.TabIndex = 0;
            this.pbCompanyLogo.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("幼圆", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.Location = new System.Drawing.Point(41, 14);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(48, 66);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "腾\r\n光";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(10, 104);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(233, 12);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copy by TengGuang Inc Co.Ltd 2008-2008";
            // 
            // lblProduce
            // 
            this.lblProduce.AutoSize = true;
            this.lblProduce.Location = new System.Drawing.Point(219, 9);
            this.lblProduce.Name = "lblProduce";
            this.lblProduce.Size = new System.Drawing.Size(155, 12);
            this.lblProduce.TabIndex = 3;
            this.lblProduce.Text = "公司:杭州腾光信息有限公司";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(219, 46);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(59, 12);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "作者:乔伟";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(219, 79);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(35, 12);
            this.lblUrl.TabIndex = 5;
            this.lblUrl.Text = "网址:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHost.Location = new System.Drawing.Point(250, 79);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(131, 12);
            this.lblHost.TabIndex = 6;
            this.lblHost.Text = "http://www.win001.com";
            this.lblHost.Click += new System.EventHandler(this.lblHost_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 127);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblProduce);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.pbCompanyLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCompanyLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblProduce;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblHost;
    }
}