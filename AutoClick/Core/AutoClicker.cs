using System;
using System.Timers;

namespace AutoClick.Core
{
    public class AutoClicker
    {
        private MouseController mouse;
        private Timer leftClickTimer;
        private Timer rightClickTimer;
        public int interval;
        public bool rightClick = false;

        public bool Enabled
        {
            get
            {
                return leftClickTimer != null && leftClickTimer.Enabled;
            }
        }

        public AutoClicker()
        {
            interval = 100;
            mouse = new MouseController();
            leftClickTimer = new Timer(interval);
            leftClickTimer.Elapsed += LeftClick_TimerElapsed;
            rightClickTimer = new Timer(interval);
            rightClickTimer.Elapsed += RightClick_TimerElapsed;
        }

        private void LeftClick_TimerElapsed(object sender, EventArgs e)
        {
            mouse.LeftClick();
        }

        private void RightClick_TimerElapsed(object sender, EventArgs e)
        {
            mouse.RightClick();
        }

        private void stopClicking()
        {
            leftClickTimer.Stop();
            rightClickTimer.Stop();
        }

        private void startClicking()
        {
            if (interval <= 0)
            {
                return;
            }

            leftClickTimer.Interval = interval;
            rightClickTimer.Interval = interval;

            if (rightClick)
            {
                rightClickTimer.Start();
            }
            else
            {
                leftClickTimer.Start();
            }
        }

        internal void Toggle()
        {
            if (leftClickTimer.Enabled || rightClickTimer.Enabled)
            {
                stopClicking();
            }
            else
            {
                startClicking();
            }
        }
    }
}
