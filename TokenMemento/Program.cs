using System;
using System.Linq;

namespace TokenMemento
{
    class Program
    {
        static void Main(string[] args)
        {
            var tm = new TokenMachine();
            var m1 = tm.AddToken(13);
            var m2 = tm.AddToken(26);
            Console.WriteLine($"Current tokens = {string.Join(", ", (tm.Tokens.Select(t => t.Value)))}");
            tm.Revert(m1);
            Console.WriteLine($"Revert to previous state: tokens = {string.Join(", ", (tm.Tokens.Select(t => t.Value)))}");
        }
    }
}
