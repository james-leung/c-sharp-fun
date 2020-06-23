using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenFilter
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T spec);
    }

    public interface IFilter<T>
    {
        List<T> Filter(IEnumerable<T> monitors, ISpecification<T> spec);
    }
}
