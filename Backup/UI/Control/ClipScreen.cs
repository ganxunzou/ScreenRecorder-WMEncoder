/***************************************************************************************
文 件 名: ClipScreen.cs
Copyright (c) 2008-2008 腾光软件有限公司
创 建 人 : 乔伟
创建日期 : 2008-11-18
简要介绍 : 
		   剪裁屏幕区域控件
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
    public partial class ClipScreen : UserControl
    {
        [DllImport("user32")]
        static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32")]
        static extern IntPtr ReleaseCapture();

        private Form screen = new Form(); // 创建一个新窗体，用于容纳整个屏幕
        private bool isMouseDown = false;
        private Point lastPoint = new Point();
        private Point oriPoint = new Point();
        // private Rectangle lastRect = new Rectangle();

        public delegate void CaptureEndProto(Rectangle rect);
        public event CaptureEndProto CaptureEnd = null; // 捕获结束事件

        public ClipScreen()
        {
            InitializeComponent();

            this.Visible = false;
        }

        private void Screen_DoubleClick(object sender, EventArgs e)
        {
            screen.Close();
        }

        /// <summary>
        /// 画交叉线
        /// </summary>
        /// <param name="point">原点坐标，相对于屏幕</param>
        /// <param name="color">颜色</param>
        private void DrawCrossLine(Point point,Color color)
        {
            ControlPaint.DrawReversibleLine(new Point(point.X, 0),
                                            new Point(point.X, SystemInformation.PrimaryMonitorSize.Height),
                                            color
                                            );
            ControlPaint.DrawReversibleLine(new Point(0, point.Y),
                                            new Point(SystemInformation.PrimaryMonitorSize.Width, point.Y),
                                            color
                                            );
        }

        private void DrawSelectArea(Rectangle rect,Color color,FrameStyle frameStyle)
        {
            ControlPaint.DrawReversibleFrame(rect,color,frameStyle);

            // 画矩形
            Graphics g = screen.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.Red), rect.X <oriPoint.X?rect.X:rect.X, rect.Y<oriPoint.Y?rect.Y:oriPoint.Y, 100, 30);
            g.DrawString(Convert.ToString(Math.Abs(rect.Width)) + " * " + Convert.ToString(Math.Abs(rect.Height)), 
                          new Font("宋体", 12), 
                          new SolidBrush(Color.White), new Point(rect.X,rect.Y)
                          );
        }

        private void Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (!lastPoint.IsEmpty)
                {
                    DrawSelectArea(new Rectangle(oriPoint.X,
                                                 oriPoint.Y,
                                                 lastPoint.X - oriPoint.X,
                                                 lastPoint.Y - oriPoint.Y
                                                 ),
                                   Color.FromArgb(0, 255, 255), 
                                   FrameStyle.Dashed
                                   );
                }
                DrawSelectArea(new Rectangle(oriPoint.X,
                                             oriPoint.Y,
                                             e.X - oriPoint.X,
                                             e.Y - oriPoint.Y
                                             ),
                               Color.FromArgb(0,255,255), 
                               FrameStyle.Dashed
                               );
                lastPoint = new Point(e.X, e.Y);
            }
            else
            {
                if (!lastPoint.IsEmpty)
                {
                    DrawCrossLine(lastPoint,Color.Red);
                }
                DrawCrossLine(new Point(e.X,e.Y), Color.Red);
                lastPoint = new Point(e.X, e.Y);
            }
        }

        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {
            DrawCrossLine(lastPoint, Color.Red);
            lastPoint = new Point();
            oriPoint = new Point(e.X, e.Y);
            isMouseDown = true;
        }

        private void Screen_MouseUp(object sender, MouseEventArgs e)
        {
            screen.Close();
        }

        public void BeginCapture()
        {
            // 设置成全显示屏显示
            screen.FormBorderStyle = FormBorderStyle.None;
            screen.Left = 0;
            screen.Top = 0;
            screen.Width = SystemInformation.PrimaryMonitorSize.Width;
            screen.Height = SystemInformation.PrimaryMonitorSize.Height;

            // 设置事件
            screen.DoubleClick += new EventHandler(Screen_DoubleClick);
            screen.MouseMove += new MouseEventHandler(Screen_MouseMove);
            screen.MouseDown += new MouseEventHandler(Screen_MouseDown);
            screen.MouseUp += new MouseEventHandler(Screen_MouseUp);

            // 将屏幕拷贝到SCREEN上
            int screenWidth = Screen.AllScreens[0].Bounds.Width;
            int screenHeight = Screen.AllScreens[0].Bounds.Height;
            Bitmap bitmap = new Bitmap(screenWidth, screenHeight);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(screenWidth, screenHeight));
            screen.BackgroundImage = bitmap;

            // 以模式对话框显示
            screen.ShowDialog();

            if (CaptureEnd != null)
            {
                CaptureEnd(new Rectangle(oriPoint.X < lastPoint.X ? oriPoint.X : lastPoint.X,
                                         oriPoint.Y < lastPoint.Y ? oriPoint.Y : lastPoint.Y,
                                         Math.Abs(lastPoint.X - oriPoint.X),
                                         Math.Abs(lastPoint.Y - oriPoint.Y)));
            }

            // 恢复原态
            lastPoint = new Point();
            oriPoint = new Point();
            isMouseDown = false;
        }

        private void ClipScreen_Resize(object sender, EventArgs e)
        {
            // 不允许调整大小
            this.Width = 16;
            this.Height = 16;
        }
    }
}
