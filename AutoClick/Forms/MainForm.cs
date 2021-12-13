using AutoClick.Core;
using AutoClick.Properties;
using System;
using System.Windows.Forms;

namespace AutoClick
{
    public partial class MainForm : Form
    {
        private LowLevelKeyboardListener listener;
        private AutoClicker autoClicker;
        private AutoDrag autoDrag;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AutoClick_Load(object sender, EventArgs e)
        {
            if (Preferences.Default.WindowLocation != null)
            {
                Location = Preferences.Default.WindowLocation;
            }

            autoClicker = new AutoClicker();
            autoClicker.interval = Preferences.Default.ClickInterval > 0 ? Preferences.Default.ClickInterval : 100;
            intervalTextBox.Text = autoClicker.interval.ToString();

            autoDrag = new AutoDrag();
            autoDrag.interval = Preferences.Default.DragInterval > 0 ? Preferences.Default.DragInterval : 100;
            autoDrag.point1 = Preferences.Default.Point1;
            autoDrag.point2 = Preferences.Default.Point2;
            textBox1.Text = autoDrag.interval.ToString();

            listener = new LowLevelKeyboardListener(KeyboardCallback);
            listener.HookKeyboard();
        }

        private void AutoClick_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
            {
                listener.UnHookKeyboard();
            }

            // Store preferences
            Preferences.Default.WindowLocation = Location;
            Preferences.Default.ClickInterval = autoClicker.interval;
            Preferences.Default.Point1 = autoDrag.point1;
            Preferences.Default.Point2 = autoDrag.point2;
            Preferences.Default.DragInterval = autoDrag.interval;

            Preferences.Default.Save();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ToggleClicking();
        }

        //Keyboard handling
        public void KeyboardCallback(int key)
        {
            if (key == Preferences.Default.ToggleAutoClick && ModifierKeys == Keys.Control)
            {
                ToggleClicking();
            }
            else if (key == Preferences.Default.ToggleAutoDrag && ModifierKeys == Keys.Control)
            {
                ToggleDrag();
            }
            else if (key == Preferences.Default.SetPoint1 && ModifierKeys == Keys.Control)
            {
                autoDrag.CapturePoint1();
            }
            else if (key == Preferences.Default.SetPoint2 && ModifierKeys == Keys.Control)
            {
                autoDrag.CapturePoint2();
            }
        }

        private void ToggleClicking()
        {
            autoClicker.Toggle();

            if (autoClicker.Enabled)
            {
                startButton.Text = "Stop";
            }
            else
            {
                startButton.Text = "Start";
            }
        }

        private void ToggleDrag()
        {
            autoDrag.Toggle();

            if (autoDrag.Enabled)
            {
                button1.Text = "Stop";
            }
            else
            {
                button1.Text = "Start";
            }
        }

        private void intervalTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            if (int.TryParse(value, out int tmp))
            {
                autoClicker.interval = tmp;
            }
            else
            {
                (sender as TextBox).Text = autoClicker.interval.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = (sender as TextBox).Text;

            if (int.TryParse(value, out int tmp))
            {
                autoDrag.interval = tmp;
            }
            else
            {
                (sender as TextBox).Text = autoDrag.interval.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleDrag();
        }
    }
}
