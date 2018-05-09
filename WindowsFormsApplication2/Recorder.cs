using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Recorder
    {
        uint WM_LBUTTONDOWN = 0x201;
        uint WM_LBUTTONUP = 0x202;

        private readonly int zoomWidth;
        private readonly int zoomHeight;
        private readonly AviWriter writer;
        private readonly IAviVideoStream videoStream;
        private readonly Thread screenThread;

        /// <summary>
        /// 上一次图片
        /// </summary>
        Bitmap lastBitmap = new Bitmap(10, 10);

        bool stop = false;

        /// <summary>
        /// 缩放
        /// </summary>
        float zoom = 1;
        /// <summary>
        /// 鼠标是否点击
        /// </summary>
        bool mouseclick = false;
        /// <summary>
        /// 钩子句柄
        /// </summary>
        int hook = 0;
        /// <summary>
        /// 录制屏幕
        /// </summary>
        /// <param name="fileName">要保存的文件名</param>
        /// <param name="codec">编码</param>
        /// <param name="quality">录制质量</param>
        /// <param name="zoom">缩放</param>
        public Recorder(string fileName, FourCC codec, int quality = 70, float zoom = 1.0F)
        {
            //设置缩放 宽高
            zoomHeight = (int)Math.Floor(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * zoom);
            zoomWidth = (int)Math.Floor(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * zoom);

            this.zoom = zoom;
            //创建视频
            writer = new AviWriter(fileName)
            {
                FramesPerSecond = 10,
                EmitIndex1 = true,
            };

            //创建视频流
            videoStream = CreateVideoStream(codec, quality);
            videoStream.Name = "Screencast";
            //开启一个线程录制屏幕
            screenThread = new Thread(RecordScreen)
            {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true
            };
            
            //钩子函数用于监控是否点击了鼠标
            // hook = WinHook.SetWindowsHookEx(HookType.WH_MOUSE_LL, WinHook.hookProc += MouseHook, Win32Api.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);

            screenThread.Start();
        }

        private IAviVideoStream CreateVideoStream(FourCC codec, int quality)
        {
            // Select encoder type based on FOURCC of codec
            if (codec == KnownFourCCs.Codecs.Uncompressed)
            {
                return writer.AddUncompressedVideoStream(zoomWidth, zoomHeight);
            }
            else if (codec == KnownFourCCs.Codecs.MotionJpeg)
            {
                return writer.AddMotionJpegVideoStream(zoomWidth, zoomHeight, quality);
            }
            else
            {
                return writer.AddMpeg4VideoStream(zoomWidth, zoomHeight, (double)writer.FramesPerSecond,
                    // It seems that all tested MPEG-4 VfW codecs ignore the quality affecting parameters passed through VfW API
                    // They only respect the settings from their own configuration dialogs, and Mpeg4VideoEncoder currently has no support for this
                    quality: quality,
                    codec: codec,
                    // Most of VfW codecs expect single-threaded use, so we wrap this encoder to special wrapper
                    // Thus all calls to the encoder (including its instantiation) will be invoked on a single thread although encoding (and writing) is performed asynchronously
                    forceSingleThreadedAccess: true);
            }
        }
        /// <summary>
        /// 停止录制
        /// </summary>
        public void Stop()
        {
            WinHook.UnhookWindowsHookEx(hook);
            lastBitmap.Dispose();
            stop = true;
        }

        private void RecordScreen()
        {
            while (!stop)
            {
                var buffer = GetScreenshot();
                // 把图片写入视频流
                videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length).Wait();
            }
            writer.Close();
        }

        private byte[] GetScreenshot()
        {
            using (Bitmap avibitmap = GetScreen())
            {
                Point mouseXY = new Point();
                Win32Api.GetCursorPos(ref mouseXY);
                using (Graphics mouseGraphics = Graphics.FromImage(avibitmap))
                {
                    //绘制鼠标位置
                    if (mouseclick)
                        mouseGraphics.DrawEllipse(new Pen(new SolidBrush(Color.Red), 10), new Rectangle(mouseXY.X - 10, mouseXY.Y - 10, 20, 20));
                    else
                        mouseGraphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 5), new Rectangle(mouseXY.X - 10, mouseXY.Y - 10, 20, 20));
                    if (zoom != 1)
                    {
                        //缩放
                        using (var copy = new Bitmap(this.zoomWidth, this.zoomHeight))
                        {
                            var buffer = new byte[copy.Width * copy.Height * 4];
                            var gcopy = Graphics.FromImage(copy);
                            gcopy.DrawImage(avibitmap, new Rectangle(new Point(0, 0), copy.Size), 0, 0, avibitmap.Width, avibitmap.Height, GraphicsUnit.Pixel);
                            gcopy.Dispose();
                            var bits = copy.LockBits(new Rectangle(0, 0, copy.Width, copy.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                            Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
                            copy.UnlockBits(bits);
                            return buffer;
                        }
                    }
                    else
                    {
                        var buffer = new byte[avibitmap.Width * avibitmap.Height * 4];
                        var bits = avibitmap.LockBits(new Rectangle(0, 0, avibitmap.Width, avibitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                        Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
                        avibitmap.UnlockBits(bits);
                        return buffer;
                    }
                }
            }

        }

        private Bitmap GetScreen()
        {
            try
            {
                var bitmap = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
                var graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(0, 0, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size);
                graphics.Dispose();
                lastBitmap.Dispose();
                lastBitmap = bitmap;
            }
            catch
            {
            }
            return (Bitmap)lastBitmap.Clone();
        }

        private int MouseHook(int nCode, int wParam, IntPtr lParam)
        {
            if (wParam == WM_LBUTTONDOWN)
                mouseclick = true;
            else if (wParam == WM_LBUTTONUP)
                mouseclick = false;
            return WinHook.CallNextHookEx(hook, nCode, wParam, lParam);
        }
    }
}
