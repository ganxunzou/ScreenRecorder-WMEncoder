/***************************************************************************************
文 件 名: ClipScreen.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-18
简要介绍 : 
		   保存文件框控件 
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TengGuang.VedioScreen.UI.Control
{
    /// <summary>
    /// 保存文件 用户控件
    /// </summary>
    public partial class SaveFile : UserControl
    {
        private string _filter;

        public SaveFile()
        {
            InitializeComponent();
        }

        private void SaveFile_Resize(object sender, EventArgs e)
        {
            this.Height = tbPath.Height;
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get
            {
                return tbPath.Text;
            }
        }

        /// <summary>
        /// 过滤格式
        /// </summary>
        public string Filter
        {
            set
            {
                _filter = value;
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            saveFileDialog.RestoreDirectory = true;

            if (_filter != string.Empty)
            {
                saveFileDialog.Filter = _filter;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = saveFileDialog.FileName;
            }
        }
    }
}
