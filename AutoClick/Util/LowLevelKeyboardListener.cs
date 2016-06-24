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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void LowLevelKeyHandler(int key);

        private HookProc _lowLevelProc;
        private LowLevelKeyHandler _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public LowLevelKeyboardListener(LowLevelKeyHandler proc)
        {
            _lowLevelProc = HookCallback;
            _proc = proc;
        }

        public void HookKeyboard()
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                IntPtr handle = GetModuleHandle(module.ModuleName);
                _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _lowLevelProc, handle, 0);

                if (_hookID == null)
                {
                    throw new Exception("Installing the hook failed");
                }
            }
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
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
                _proc(vkCode);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
