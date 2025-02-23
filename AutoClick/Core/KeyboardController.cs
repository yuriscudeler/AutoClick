using System.Windows.Forms;
using static AutoClick.Core.WinApi;

namespace AutoClick.Core
{
    internal class KeyboardController
    {
        internal void Press(Keys key)
        {
            KeyboardEvent(key, "down");
        }

        internal void Release(Keys key)
        {
            KeyboardEvent(key, "up");
        }
    }
}
