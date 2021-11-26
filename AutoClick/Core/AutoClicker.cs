using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AutoClick.Core
{
    public class AutoClicker
    {
        private MouseController mouse;
        private Timer Timer1;
        public int interval;

        public bool Enabled
        {
            get
            {
                return Timer1 != null && Timer1.Enabled;
            }
        }

        public AutoClicker()
        {
            interval = 100;
            mouse = new MouseController();
            Timer1 = new Timer(interval);
            Timer1.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            mouse.LeftClick();
        }

        private void stopClicking()
        {
            Timer1.Stop();
        }

        private void startClicking()
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
                stopClicking();
            }
            else
            {
                startClicking();
            }
        }
    }
}
