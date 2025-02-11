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
            autoClicker = new AutoClicker();
            autoClicker.interval = Preferences.Default.ClickInterval > 0 ? Preferences.Default.ClickInterval : 100;
            clickIntervalTextBox.Text = autoClicker.interval.ToString();

            autoDrag = new AutoDrag();
            autoDrag.interval = Preferences.Default.DragInterval > 0 ? Preferences.Default.DragInterval : 100;
            autoDrag.point1 = Preferences.Default.Point1;
            autoDrag.point2 = Preferences.Default.Point2;
            dragIntervalTextBox.Text = autoDrag.interval.ToString();
            textBox2.Text = autoDrag.point1.ToString();
            textBox3.Text = autoDrag.point2.ToString();

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
            Preferences.Default.ClickInterval = autoClicker.interval;
            Preferences.Default.Point1 = autoDrag.point1;
            Preferences.Default.Point2 = autoDrag.point2;
            Preferences.Default.DragInterval = autoDrag.interval;

            // TODO: save selected keys

            Preferences.Default.Save();
        }

        //Keyboard handling
        public void KeyboardCallback(int key)
        {
            //if (key == Preferences.Default.ToggleClickKey && ModifierKeys == (Keys)Preferences.Default.ToggleClickModifierKey)
            if (key == Preferences.Default.ToggleClickKey && ModifierKeys == Keys.Shift)
            {
                autoClicker.Toggle();
            }
            //else if (key == Preferences.Default.ToggleDragKey && ModifierKeys == (Keys)Preferences.Default.ToggleDragModifierKey)
            else if (key == Preferences.Default.ToggleDragKey && ModifierKeys == Keys.Shift)
            {
                autoDrag.Toggle();
            }
            else if (key == Preferences.Default.SetPoint1 && ModifierKeys == Keys.Shift)
            {
                autoDrag.CapturePoint1();
                textBox2.Text = autoDrag.point1.ToString();
            }
            else if (key == Preferences.Default.SetPoint2 && ModifierKeys == Keys.Shift)
            {
                autoDrag.CapturePoint2();
                textBox3.Text = autoDrag.point2.ToString();
            }
        }

        private void clickIntervalTextBox_TextChanged(object sender, EventArgs e)
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

        private void dragIntervalTextBox_TextChanged(object sender, EventArgs e)
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

        private void autoDragHoldCtrl_CheckedChanged(object sender, EventArgs e)
        {
            autoDrag.holdCtrl = (sender as CheckBox).Checked;
        }

        private string GetKeyStrokeString(int key, Keys modifiers)
        {
            KeysConverter converter = new KeysConverter();
            string str = string.Empty;

            switch (ModifierKeys)
            {
                case Keys.Control | Keys.Alt | Keys.Shift:
                    str = "CTRL + ALT + SHIFT + ";
                    break;
                case Keys.Control | Keys.Alt:
                    str = "CTRL + ALT + ";
                    break;
                case Keys.Control | Keys.Shift:
                    str = "CTRL + SHIFT + ";
                    break;
                case Keys.Alt | Keys.Shift:
                    str = "ALT + SHIFT + ";
                    break;
                case Keys.Control:
                    str = "CTRL + ";
                    break;
                case Keys.Alt:
                    str = "ALT + ";
                    break;
                case Keys.Shift:
                    str = "SHIFT + ";
                    break;
                default:
                    break;
            }
            
            str += converter.ConvertToString(key);

            return str;
        }

        private void autoClickToggleKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            string value = (sender as TextBox).Text;

            if (int.TryParse(value, out int key))
            {
                Preferences.Default.ToggleClickModifierKey = (int)ModifierKeys;
                Preferences.Default.ToggleClickKey = key;

                (sender as TextBox).Text = GetKeyStrokeString(key, ModifierKeys);
            }
            else
            {
                (sender as TextBox).Text = GetKeyStrokeString(Preferences.Default.ToggleClickKey, (Keys)Preferences.Default.ToggleClickModifierKey);
            }
        }

        private void autoDragToggleKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            string value = (sender as TextBox).Text;

            if (int.TryParse(value, out int key))
            {
                Preferences.Default.ToggleDragModifierKey = (int)ModifierKeys;
                Preferences.Default.ToggleDragKey = key;

                (sender as TextBox).Text = GetKeyStrokeString(key, ModifierKeys);
            }
            else
            {
                (sender as TextBox).Text = GetKeyStrokeString(Preferences.Default.ToggleDragKey, (Keys)Preferences.Default.ToggleDragModifierKey);
            }
        }

        private void mouseBtnCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            autoClicker.rightClick = (sender as CheckBox).Checked;
        }
    }
}
