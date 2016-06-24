using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClick.Util
{
    public class Setting
    {
        public string Name;
        public string Description;

        public Setting(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}
