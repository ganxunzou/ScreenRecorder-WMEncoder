namespace TengGuang.VedioScreen.UI.Control
{
    partial class FindWindow
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbHand = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHand)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbHand
            // 
            this.pbHand.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbHand.Image = global::TengGuang.VedioScreen.UI.Properties.Resources.hand;
            this.pbHand.Location = new System.Drawing.Point(0, 0);
            this.pbHand.Name = "pbHand";
            this.pbHand.Size = new System.Drawing.Size(25, 21);
            this.pbHand.TabIndex = 1;
            this.pbHand.TabStop = false;
            this.pbHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbHand_MouseDown);
            this.pbHand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbHand_MouseUp);
            // 
            // FindWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.pbHand);
            this.Name = "FindWindow";
            this.Size = new System.Drawing.Size(16, 16);
            this.Resize += new System.EventHandler(this.FindWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbHand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbHand;

    }
}
