/***************************************************************************************
�� �� ��: ClipScreen.cs
Copyright (c) 2008-2008 �ڹ�������޹�˾
�� �� �� : ��ΰ
�������� : 2008-11-18
��Ҫ���� : 
		   �����ļ���ؼ� 
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
    /// �����ļ� �û��ؼ�
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
        /// �ļ�·��
        /// </summary>
        public string FilePath
        {
            get
            {
                return tbPath.Text;
            }
        }

        /// <summary>
        /// ���˸�ʽ
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
