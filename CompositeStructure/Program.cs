using System;
using System.Collections.Generic;

namespace CompositeStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new SingleValue() { Value = 2 };
            var y = new ManyValues() { 3, 4 };
            var z = new List<IValueContainer> { x, y };
            Console.WriteLine($"The sum of the given numbers is {z.Sum()}");
        }
    }
}
