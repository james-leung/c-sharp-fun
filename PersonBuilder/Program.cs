using System;

namespace PersonBuilder2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var me = Person.New.Called("James").WorksAs("Developer").Build();
            Console.WriteLine(me);
        }
    }
}
