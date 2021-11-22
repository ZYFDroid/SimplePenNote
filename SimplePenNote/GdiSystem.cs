using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyGDIFramework
{

    public class GdiSystem : IDisposable
    {
        Form thisWindow;

        /// <summary>
        /// 在FormLoad中调用这个方法
        /// </summary>
        /// <param name="attachForm"></param>
        public GdiSystem(Form attachForm)
        {
            thisWindow = attachForm;
            thisWindow.FormBorderStyle = FormBorderStyle.None;
            if (attachForm.Handle != IntPtr.Zero)
            {
                int windowLong = Win32.GetWindowLong(thisWindow.Handle, Win32.GWL_EXSTYLE);
                windowLong |= Win32.WS_EX_LAYERED;
                Win32.SetWindowLong(thisWindow.Handle, Win32.GWL_EXSTYLE, windowLong);
            }
            else
            {
                throw new AccessViolationException("窗口没有初始化");
            }
            oldBits = IntPtr.Zero;
            screenDC = Win32.GetDC(IntPtr.Zero);
            hBitmap = IntPtr.Zero;
            memDc = Win32.CreateCompatibleDC(screenDC);
            blendFunc.BlendOp = Win32.AC_SRC_OVER;
            blendFunc.SourceConstantAlpha = 255;
            blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
            blendFunc.BlendFlags = 0;

            initBitmaps();

        }

        private void initBitmaps()
        {
            thisBitmap = new Bitmap(thisWindow.Width, thisWindow.Height);
            thisGraphics = Graphics.FromImage(thisBitmap);
            bitMapSize = new Win32.Size(thisBitmap.Width, thisBitmap.Height);
        }
        /// <summary>
        /// 获取一个可以绘制的画布对象，在上面绘制窗体内容
        /// </summary>
        /// <param name="clearGraphics"></param>
        /// <returns></returns>
        public Graphics Graphics
        {
            get
            {
                return thisGraphics;
            }
        }

        public int IWidth {
            get {
                return thisBitmap.Width;
            }
        }
        public int IHeight
        {
            get
            {
                return thisBitmap.Height;
            }
        }
        public Size ISize
        {
            get
            {
                return thisBitmap.Size;
            }
        }
        /// <summary>
        /// 画完之后提交绘制内容
        /// </summary>
        public void UpdateWindow()
        {
            SetBits(thisBitmap);
        }
        IntPtr oldBits;
        IntPtr screenDC;
        IntPtr hBitmap;
        IntPtr memDc;
        Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();

        Win32.Point topLoc = new Win32.Point(0, 0);
        Win32.Size bitMapSize;
        Win32.Point srcLoc = new Win32.Point(0, 0);
        private void SetBits(Bitmap bitmap)
        {

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("The picture must be 32bit picture with alpha channel.");
            try
            {
                bitMapSize.cx = thisWindow.Width;
                bitMapSize.cy = thisWindow.Height;
                topLoc.x = thisWindow.Left;
                topLoc.y = thisWindow.Top;
                hBitmap = thisBitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);
                Win32.UpdateLayeredWindow(thisWindow.Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
            }
        }

        public void Dispose()
        {
            Win32.ReleaseDC(IntPtr.Zero, screenDC);
            Win32.DeleteDC(memDc);
        }

        private Bitmap thisBitmap;
        private Graphics thisGraphics;


        private class Win32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Size
            {
                public Int32 cx;
                public Int32 cy;

                public Size(Int32 x, Int32 y)
                {
                    cx = x;
                    cy = y;
                }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct Point
            {
                public Int32 x;
                public Int32 y;

                public Point(Int32 x, Int32 y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            public const byte AC_SRC_OVER = 0;
            public const Int32 ULW_ALPHA = 2;
            public const byte AC_SRC_ALPHA = 1;
            public const int GWL_EXSTYLE = -20;
            public const int WS_EX_LAYERED = 0x80000;

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

            [DllImport("user32.dll", ExactSpelling = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteDC(IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int DeleteObject(IntPtr hObj);

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);

            [DllImport("user32.dll", EntryPoint = "GetWindowLongA")]
            public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

            [DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
            public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        }
    }

}
