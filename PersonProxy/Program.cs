using System;

namespace PersonProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private Person _person;

        public ResponsiblePerson(Person person)
        {
            _person = person;
        }

        public string Drive()
        {
            return Age > 16 ? _person.Drive() : "too young";
        }

        public string Drink()
        {
            return Age > 18 ? _person.Drink() : "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public int Age
        {
            get => _person.Age;
            set => _person.Age = value;
        }
    }
}
