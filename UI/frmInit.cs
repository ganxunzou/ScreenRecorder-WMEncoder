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
        const int SWP_NOSIZE = 1;  // ���� cx,cy ���ã����ִ���ԭ��С 
        const int SWP_NOMOVE = 2;  // ���� x,y ���ã����ִ���ԭλ��
        const int HWND_TOPMOST = -1; // ���д��ڵ��ϲ�
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int xc, int cy, uint uFlags);

        public frmInit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����ͼƬ������������
        /// </summary>
        /// <param name="Picture">ͼ��</param>
        /// <param name="TransparentColor">͸��ɫ</param>
        /// <returns>Region����</returns>
        public static Region BmpRgn(Bitmap picture)
        {
            Color transparentColor = picture.GetPixel(0, 0); // ��ͼƬ�ĵ�һ�����ص���ɫΪ͸��ɫ

            int nWidth = picture.Width;
            int nHeight = picture.Height;
            Region rgn = new Region();
            rgn.MakeEmpty();
            bool isTransRgn; // ǰһ�����Ƿ���͸����
            Color curColor; // ��ǰ�����ɫ
            Rectangle curRect = new Rectangle();
            curRect.Height = 1;
            int x = 0, y = 0;

            // ������ɨ�����ͼƬ���ҳ���͸��ɫ�������򲢺ϲ�������
            for (y = 0; y < nHeight; ++y)
            {
                isTransRgn = true;
                for (x = 0; x < nWidth; ++x)
                {
                    curColor = picture.GetPixel(x, y);
                    if (curColor == transparentColor || x == nWidth - 1) // �������͸��ɫ����β
                    {
                        if (isTransRgn == false) // �˳���Ч��
                        {
                            curRect.Width = x - curRect.X;
                            rgn.Union(curRect);
                        }
                    }
                    else // ��͸��ɫ
                    {
                        if (isTransRgn == true) // ������Ч��
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
            // ���óɶ��㴰��
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);

            this.Text = "��ʼ�����";
            this.Region = BmpRgn(Properties.Resources.ProcessBack);
            // ���ý�����
            pbRegister.Maximum = 11;
            pbRegister.Step = 1;

            // �������߳̽��к�̨������ֹ�����޷��ػ�
            System.Threading.Thread t = new System.Threading.Thread(SetProcessThread);
            t.Start();
            //timer.Enabled = true;
        }

        private void SetProcessThread()
        {
            // ����һ���µĽ���������Ϣ���󲢸���ֵ
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;
            pInfo.FileName = "cmd.exe";
            pInfo.RedirectStandardError = true;
            pInfo.RedirectStandardInput = true;
            pInfo.RedirectStandardOutput = true;

            // ��������
            Process p = Process.Start(pInfo);

            // ʹ������ܵ���Ŀ�����������Ϣ
            p.StandardInput.WriteLine("@echo off");
            p.StandardInput.WriteLine("cd Encoder");
            p.StandardInput.WriteLine("reg.bat");
            p.StandardInput.WriteLine("exit");

            // ѭ����ȡĿ�����(CMD.exe)���ص���Ϣ
            while (!p.StandardOutput.EndOfStream)
            {
                string outputString = p.StandardOutput.ReadLine();

                // ���緵������Ϣ ���� ע��ɹ� ʹ���ȼ� 1
                if (outputString.IndexOf("ע��ɹ�") > 0)
                {
                    try
                    {
                        lblDllName.Text = outputString.Replace("ע��ɹ�","");
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