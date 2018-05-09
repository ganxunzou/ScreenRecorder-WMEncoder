using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    public class Win32Api
    {
        [DllImport("user32.dll ")]
        public static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll ")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
