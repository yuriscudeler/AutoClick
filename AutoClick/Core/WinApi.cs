using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AutoClick.Core
{
    internal static class WinApi
    {
        #region function imports
        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        internal delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("USER32.DLL")]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        internal static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        private const int SRCCOPY = 0x00CC0020;
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hObject, int nXDest, int
        nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int
        nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int
        nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;

            internal int Width => right - left;
            internal int Height => bottom - top;

            public override string ToString()
            {
                return $"left:{left} top:{top} right:{right} bottom:{bottom} width:{Width} height:{Height}";
            }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll")]
        private static extern IntPtr GetClientRect(IntPtr hWnd, ref Rect rect);
        [DllImport("user32.dll")]
        internal static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        internal const uint MOUSE_MOVE       =   0x0001;
        internal const uint MOUSE_LEFTDOWN   =   0x0002;
        internal const uint MOUSE_LEFTUP     =   0x0004;
        internal const uint MOUSE_RIGHTDOWN  =   0x0008;
        internal const uint MOUSE_RIGHTUP    =   0x0010;
        internal const uint MOUSE_MIDDLEDOWN =   0x0020;
        internal const uint MOUSE_MIDDLEUP   =   0x0040;
        internal const uint MOUSE_WHEEL      =   0x0800;
        internal const uint MOUSE_ABSOLUTE   =   0x8000;
        #endregion

        #region static methods

        internal static void ManagedSendKeys(string keys)
        {
            SendKeys.SendWait(keys);
        }

        internal static void ManagedSendKeys(string keys, string windowName)
        {
            if (WindowActive(windowName))
            {

                ManagedSendKeys(keys);
            }
        }
        
        internal static void ManagedSendKeys(string keys, IntPtr handle)
        {
            if (WindowActive(handle))
            {
                ManagedSendKeys(keys);
            }
        }

        internal static void KeyboardEvent(Keys key, string state = "down")
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            var _state = state == "up" ? KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP : KEYEVENTF_EXTENDEDKEY;
            keybd_event((byte)key, 0x45, (uint)_state, (UIntPtr)0);
        }

        internal static void MouseClick(string button, string windowName)
        {
            if (WindowActive(windowName))
                MouseClick(button);
        }

        internal static void MouseClick(string button)
        {

            switch (button.ToLower())
            {
                case "left":
                    mouse_event(MOUSE_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSE_LEFTUP, 0, 0, 0, 0);
                    break;
                case "right":
                    mouse_event(MOUSE_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSE_RIGHTUP, 0, 0, 0, 0);
                    break;
                case "middle":
                    mouse_event(MOUSE_MIDDLEDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSE_MIDDLEUP, 0, 0, 0, 0);
                    break;
            }
        }

        internal static void MouseStartDrag()
        {
            mouse_event(MOUSE_LEFTDOWN, 0, 0, 0, 0);
        }

        internal static void MouseStopDrag()
        {
            mouse_event(MOUSE_LEFTUP, 0, 0, 0, 0);
        }

        internal static void MouseScroll(int distance, int direction)
        {
            mouse_event(MOUSE_WHEEL, 0, 0, (uint)(distance * direction), 0);
        }

        internal static void MouseClick(string button, int state)
        {
            switch (button.ToLower())
            {
                case "left":
                    switch (state)
                    {
                        case 1:
                            mouse_event(MOUSE_LEFTUP, 0, 0, 0, 0);
                            break;
                        case 0:
                            mouse_event(MOUSE_LEFTDOWN, 0, 0, 0, 0);
                            break;
                    }
                    break;
                case "right":
                    switch (state)
                    {
                        case 1:
                            mouse_event(MOUSE_RIGHTUP, 0, 0, 0, 0);
                            break;
                        case 0:
                            mouse_event(MOUSE_RIGHTDOWN, 0, 0, 0, 0);
                            break;
                    }
                    break;
                case "middle":
                    switch (state)
                    {
                        case 1:
                            mouse_event(MOUSE_MIDDLEUP, 0, 0, 0, 0);
                            break;
                        case 0:
                            mouse_event(MOUSE_MIDDLEDOWN, 0, 0, 0, 0);
                            break;
                    }
                    break;
            }
        }

        internal static void MouseMove(int x, int y)
        {
            SetCursorPos(x, y);
        }

        internal static void WindowMove(int x, int y, string windowName, int width, int height)
        {
            IntPtr window = FindWindow(null, windowName);
            if (window != IntPtr.Zero)
                MoveWindow(window, x, y, width, height, true);
        }

        internal static void WindowMove(int x, int y, string windowName)
        {
            WindowMove(x, y, windowName, 800, 600);
        }

        internal static bool WindowActive(string windowName)
        {
            IntPtr myHandle = FindWindow(null, windowName);
            IntPtr foreGround = GetForegroundWindow();
            if (myHandle != foreGround)
                return false;
            else
                return true;
        }

        internal static bool WindowActive(IntPtr myHandle)
        {
            IntPtr foreGround = GetForegroundWindow();
            if (myHandle != foreGround)
                return false;
            else
                return true;
        }

        internal static void WindowActivate(string windowName)
        {
            IntPtr myHandle = FindWindow(null, windowName);
            SetForegroundWindow(myHandle);
        }

        internal static void WindowActivate(IntPtr handle)
        {
            SetForegroundWindow(handle);
        }

        internal static Bitmap CreateScreenshot(IntPtr hWnd)
        {
            // hWnd = GetDesktopWindow();
            IntPtr hSourceDC = GetWindowDC(hWnd);
            Rect rect = new Rect();
            GetWindowRect(hWnd, ref rect);
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;
            IntPtr hDestDC = CreateCompatibleDC(hSourceDC);
            IntPtr hBitmap = CreateCompatibleBitmap(hSourceDC, width, height);
            IntPtr hObject = SelectObject(hDestDC, hBitmap);
            BitBlt(hDestDC, 0, 0, width, height, hSourceDC, 0, 0, SRCCOPY);
            SelectObject(hDestDC, hObject);
            DeleteDC(hDestDC);
            ReleaseDC(hWnd, hSourceDC);
            Bitmap screenshot = Bitmap.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);
            return screenshot;
        }

        internal static Bitmap CaptureApplication(IntPtr hWnd)
        {
            // hWnd = GetDesktopWindow();
            var rect = new Rect();
            GetWindowRect(hWnd, ref rect);
            // Console.WriteLine(rect.ToString());
            // GetClientRect(hWnd, ref rect);
            Console.WriteLine(rect.ToString());
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(rect.Width, rect.Height), CopyPixelOperation.SourceCopy);
            }

            return bmp;
        }

        internal static Bitmap PrintWindow(IntPtr hWnd)
        {
            // hWnd = GetDesktopWindow();
            Rect rect = new Rect();
            GetWindowRect(hWnd, ref rect);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            PrintWindow(hWnd, hdcBitmap, 0);
            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();
            return bmp;
        }
        #endregion
    }
}
