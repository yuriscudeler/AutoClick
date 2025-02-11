using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClick.Core
{
    class MouseController
    {
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        internal void LeftClick()
        {
            LeftClick(0, 0);
        }

        internal void RightClick()
        {
            RightClick(0, 0);
        }

        private void LeftClick(uint x, uint y)
        {
            User32.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void RightClick(uint x, uint y)
        {
            User32.mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }

        private void LeftDoubleClick(uint x, uint y)
        {
            User32.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            Thread.Sleep(100);
            User32.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void RightDoubleClick(uint x, uint y)
        {
            User32.mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
            Thread.Sleep(100);
            User32.mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }

        internal void LeftDown()
        {
            User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        internal void LeftUp()
        {
            User32.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        internal void MoveTo(Point p)
        {
            var screenBounds = Screen.PrimaryScreen.Bounds;
            uint x = Convert.ToUInt32(p.X * 65535 / screenBounds.Width);
            uint y = Convert.ToUInt32(p.Y * 65535 / screenBounds.Height);

            User32.mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        internal void MoveTo(int x, int y)
        {
            MoveTo(new Point(x, y));
        }
    }
}
