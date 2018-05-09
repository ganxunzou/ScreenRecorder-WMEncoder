/***************************************************************************************
文 件 名: FindWindow.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-18
简要介绍 : 
		   获得窗体的位置控件
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TengGuang.VedioScreen.UI.Control
{
    public partial class FindWindow : UserControl
    {
        [DllImport("user32")]
        static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32")]
        static extern IntPtr ReleaseCapture();
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(IntPtr xPoint, IntPtr yPoint);
        [DllImport("user32.dll")]
        static extern IntPtr GetCursorPos(out PointAPI lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public int Width() { return right - left; }
            public int Height() { return bottom - top; }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PointAPI
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowRect(IntPtr hwnd, ref RECT rc);
        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(IntPtr hWnd, IntPtr iMsg, IntPtr wParam, IntPtr lParam);

        private Rectangle curRect = new Rectangle();

        private Color LineColor
        {
            get
            {
                return Color.FromArgb(0, 255, 255);   // 红色的反色
            }
        }

        public delegate void CaptureBeginProto();
        public event CaptureBeginProto CaptureBegin = null; // 捕获结束事件

        public delegate void CaptureEndProto(Rectangle rect);
        public event CaptureEndProto CaptureEnd = null; // 捕获结束事件

        public FindWindow()
        {
            InitializeComponent();
        }

        private void FindWindow_Load(object sender, EventArgs e)
        {
            //this.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PointAPI p;
            GetCursorPos(out p);
            Point pc = new Point(p.X, p.Y);
            //p1 = PointToScreen(p1);
            //Point pc = PointToScreen(p1);
            RECT rect = new RECT();
            IntPtr Handle = (WindowFromPoint((IntPtr)pc.X, (IntPtr)pc.Y));
            GetWindowRect(Handle, ref rect);
            curRect = new Rectangle(rect.left, rect.top, rect.Width(), rect.Height());
            
            timer.Enabled = false;
            // 画一根红线
            ControlPaint.DrawReversibleFrame(curRect, LineColor, FrameStyle.Thick);
            System.Threading.Thread.Sleep(timer.Interval);
            // 擦除刚才所绘制的边框
            ControlPaint.DrawReversibleFrame(curRect, LineColor, FrameStyle.Thick);
            timer.Enabled = true;

            //System.Diagnostics.Debug.Print(curRect.Left.ToString() + "-" + curRect.Right);
        }

        private void pbHand_MouseUp(object sender, MouseEventArgs e)
        {
            if (timer.Enabled)
            {
                if (CaptureEnd != null)
                {
                    CaptureEnd(curRect);
                }

                // 将状态恢复
                timer.Enabled = false;
                this.Visible = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void pbHand_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            if (CaptureBegin != null)
            {
                CaptureBegin();
            }
            this.Visible = false;
            SetCapture(this.pbHand.Handle);
            timer.Enabled = true;
        }

        private void FindWindow_Resize(object sender, EventArgs e)
        {
            // 不允许调整大小 
            this.Height = 16;
            this.Width = 16;
        }
    }
}
