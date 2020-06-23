using System;

namespace PersonProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();

            Person person = pb
                .Lives
                    .At("321 Mavericks Rd")
                    .In("Liverpool")
                    .WithPostalCode("Random postal code")
                .Works
                    .At("Big Tech Company")
                    .AsA("Software Developer")
                    .Earning(35000);

            Console.WriteLine(person);
        }
    }
}
