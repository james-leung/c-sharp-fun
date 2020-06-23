using System;
using System.Collections.Generic;
using System.Threading;

namespace ScreenFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor { Name = "Samsung S345", Screen = Screen.CurvedScreen, Type = ScreenType.OLED },
                new ComputerMonitor { Name = "Philips P532", Screen = Screen.WideScreen, Type = ScreenType.LCD },
                new ComputerMonitor { Name = "LG L888", Screen = Screen.WideScreen, Type = ScreenType.LED },
                new ComputerMonitor { Name = "Samsung S999", Screen = Screen.WideScreen, Type = ScreenType.OLED },
                new ComputerMonitor { Name = "Dell D2J47", Screen = Screen.CurvedScreen, Type = ScreenType.LCD }
            };

            var filter = new MonitorFilter();
            var monitorsWithLCD = filter.Filter(monitors, new MonitorTypeSpec(ScreenType.LCD));
            Console.WriteLine("Monitors with LCD screen type:");
            foreach (var mon in monitorsWithLCD)
            {
                Console.WriteLine($"Name: {mon.Name}, screen type: {mon.Type}, screen: {mon.Screen}");
            }

            var monitorsWithWideScreen = filter.Filter(monitors, new ScreenSpec(Screen.WideScreen));
            Console.WriteLine("Monitors with wide screens:");
            foreach (var mon in monitorsWithWideScreen)
            {
                Console.WriteLine($"Name: {mon.Name}, screen type: {mon.Type}, screen: {mon.Screen}");
            }
        }
    }
}
