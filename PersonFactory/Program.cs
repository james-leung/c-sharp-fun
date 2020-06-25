using System;

namespace PersonFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var pf = new PersonFactory();
            var person = pf.CreatePerson("James");
            Console.WriteLine($"You've created a new person, {person.Name}.");
        }
    }
}
