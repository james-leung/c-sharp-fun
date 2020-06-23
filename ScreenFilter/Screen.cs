using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenFilter
{
    public enum ScreenType
    {
        OLED, LCD, LED
    }
    public enum Screen
    {
        WideScreen, CurvedScreen
    }

    public class ComputerMonitor
    {
        public string Name { get; set; }
        public ScreenType Type { get; set; }
        public Screen Screen { get; set; }
    }
}
