using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenFilter
{
    public class MonitorTypeSpec : ISpecification<ComputerMonitor>
    {
        private readonly ScreenType _type;
        public MonitorTypeSpec(ScreenType type)
        {
            _type = type;
        }
        public bool IsSatisfied(ComputerMonitor item) => item.Type == _type;
    }
    public class ScreenSpec : ISpecification<ComputerMonitor>
    {
        private readonly Screen _screen;
        public ScreenSpec(Screen screen)
        {
            _screen = screen;
        }
        public bool IsSatisfied(ComputerMonitor mon)
        {
            return mon.Screen == _screen;
        }
    }
}
