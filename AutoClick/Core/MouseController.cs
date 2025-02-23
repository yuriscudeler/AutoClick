using System.Drawing;
using System.Threading;
using static AutoClick.Core.WinApi;

namespace AutoClick.Core
{
    internal class MouseController
    {
        internal void LeftClick()
        {
            mouse_event(MOUSE_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSE_LEFTUP, 0, 0, 0, 0);
        }

        internal void RightClick()
        {
            mouse_event(MOUSE_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSE_RIGHTUP, 0, 0, 0, 0);
        }

        private void DoubleLeftClick(uint x, uint y)
        {
            LeftClick();
            Thread.Sleep(100);
            LeftClick();
        }

        private void DoubleRightClick(uint x, uint y)
        {
            RightClick();
            Thread.Sleep(100);
            RightClick();
        }

        internal void LeftDown()
        {
            mouse_event(MOUSE_LEFTDOWN, 0, 0, 0, 0);
        }

        internal void LeftUp()
        {
            mouse_event(MOUSE_LEFTUP, 0, 0, 0, 0);
        }

        internal void RightDown()
        {
            mouse_event(MOUSE_RIGHTDOWN, 0, 0, 0, 0);
        }

        internal void RightUp()
        {
            mouse_event(MOUSE_RIGHTUP, 0, 0, 0, 0);
        }

        internal void MoveTo(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }

        internal void MoveTo(int x, int y)
        {
            SetCursorPos(x, y);
        }
    }
}
