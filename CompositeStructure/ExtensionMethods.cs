using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CompositeStructure
{
    public interface IValueContainer
    {
        IEnumerator<int> GetEnumerator();
    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {
        IEnumerator<int> IValueContainer.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
