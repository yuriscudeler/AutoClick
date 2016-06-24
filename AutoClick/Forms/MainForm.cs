using AutoClick.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClick
{
    public partial class AutoClick : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private int delay;
        private int interval;

        private LowLevelKeyboardListener listener;

        public AutoClick()
        {
            InitializeComponent();
        }

        private void AutoClick_Load(object sender, EventArgs e)
        {
            if (Preferences.Default.WindowLocation != null)
            {
                this.Location = Preferences.Default.WindowLocation;
            }

            delay = 100;
            interval = 100;

            delayTextBox.Text = delay.ToString();
            intervalTextBox.Text = interval.ToString();

            listener = new LowLevelKeyboardListener(KeyboardCallback);
            listener.HookKeyboard();
        }

        private void AutoClick_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
            {
                listener.UnHookKeyboard();
            }

            Preferences.Default.WindowLocation = this.Location;
            Preferences.Default.Save();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (ClickTimer.Enabled)
            {
                stopClicking();
            }
            else
            {
                if (interval <= 0)
                {
                    return;
                }

                startClicking();
            }
        }

        private void delayTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            int tmp = 0;
            if (int.TryParse(value, out tmp))
            {
                delay = tmp;
            }
            else
            {
                (sender as TextBox).Text = delay.ToString();
            }
        }

        private void intervalTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            int tmp = 0;
            if (int.TryParse(value, out tmp))
            {
                interval = tmp;
            }
            else
            {
                (sender as TextBox).Text = interval.ToString();
            }
        }

        private void ClickTimerTick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void stopClicking()
        {
            ClickTimer.Stop();
            startButton.Text = "Start";
        }

        private void startClicking()
        {
            startButton.Text = "Stop";
            ClickTimer.Interval = interval;
            Thread.Sleep(delay);
            ClickTimer.Start();
        }

        //Keyboard handling
        public void KeyboardCallback(int key)
        {
            if (key == Preferences.Default.ToggleClicking)
            {
                if (ClickTimer.Enabled)
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
}
