using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenFilter
{
    public class MonitorFilter : IFilter<ComputerMonitor>
    {
        public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> spec)
        {
            return monitors.Where(m => spec.IsSatisfied(m)).ToList();
        }
    }
}
