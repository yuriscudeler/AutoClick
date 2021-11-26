using AutoClick.Core;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClick
{
    public class LowLevelKeyboardListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int HC_NOREMOVE = 3;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate void KeyHandler(int key);

        private KeyHandler Callback;
        private IntPtr HookID;

        public LowLevelKeyboardListener(KeyHandler cb)
        {
            Callback = cb;
        }

        public void HookKeyboard()
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr handle = GetModuleHandle(module.ModuleName);
                HookID = User32.SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, handle, 0);

                if (HookID == null)
                {
                    throw new Exception("Installing the hook failed");
                }
            }
        }

        public void UnHookKeyboard()
        {
            User32.UnhookWindowsHookEx(HookID);
        }

        /// <summary>
        /// Function called by the system when we receive a keyboard event: https://msdn.microsoft.com/en-us/library/windows/desktop/ms644985.aspx
        /// </summary>
        /// <param name="nCode">int</param>
        /// <param name="wParam">The identifier of the keyboard message. This parameter can be one of the following messages: WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP</param>
        /// <param name="lParam">A pointer to a KBDLLHOOKSTRUCT structure</param>
        /// <returns></returns>
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (int)wParam == WM_KEYDOWN)
            {
                //Console.WriteLine($"wParam: 0x{wParam.ToInt32():X} lParam: 0x{lParam.ToInt32():X}");
                int vkCode = Marshal.ReadInt32(lParam);
                Callback(vkCode);
            }
            return User32.CallNextHookEx(HookID, nCode, wParam, lParam);
        }
    }
}
