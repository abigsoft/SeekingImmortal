using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entity
{
    public class SystemSetting
    {
        public bool isMute { get; set; } = false;
        public bool isAutoRefresh { get; set; } = false;
        public bool isAutoCollapsed { get; set; } = true;
        public bool isSystemLogToWorld { get; set; } = false;

        public WorldColor worldColor { get; set; } = new WorldColor();
    }

    public class WorldColor
    {
        public string title_str = "";
        public string title_color = "";
        public string message_color = "";
        public string friends_color = "";
    }
}
