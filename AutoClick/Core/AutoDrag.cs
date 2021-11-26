﻿using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace AutoClick.Core
{
    public class AutoDrag
    {
        private MouseController mouse;
        private System.Timers.Timer Timer1;
        public int interval;
        public Point point1;
        public Point point2;
        public bool holdCtrl;

        internal bool Enabled
        {
            get
            {
                return Timer1 != null && Timer1.Enabled;
            }
        }

        public AutoDrag()
        {
            interval = 2000;
            mouse = new MouseController();
            Timer1 = new System.Timers.Timer(interval);
            Timer1.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            Timer1.Stop();

            if (holdCtrl)
            {
                // press ctrl
            }

            mouse.MoveTo(point1);
            mouse.LeftDown();
            Thread.Sleep(5);
            mouse.MoveTo(point2);
            mouse.LeftUp();

            if (holdCtrl)
            {
                // release ctrl
            }

            Timer1.Start();
        }

        private void stopDrag()
        {
            Timer1.Stop();
        }

        private void startDrag()
        {
            if (interval <= 0)
            {
                return;
            }

            Timer1.Interval = interval;
            Timer1.Start();
        }

        internal void Toggle()
        {
            if (Timer1.Enabled)
            {
                stopDrag();
            }
            else
            {
                startDrag();
            }
        }

        internal void SetPoint1()
        {
            point1 = Cursor.Position;
        }

        internal void SetPoint2()
        {
            point2 = Cursor.Position;
        }
    }
}
