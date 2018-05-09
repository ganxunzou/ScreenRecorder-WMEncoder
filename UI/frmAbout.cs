using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TengGuang.VedioScreen.UI
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lblHost_Click(object sender, EventArgs e)
        {
            Process p = new Process();

            p.StartInfo.FileName = "http://www.win001.com";

            p.Start();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = "¹ØÓÚ";
            this.ShowInTaskbar = false;
        }
    }
}