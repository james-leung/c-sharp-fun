using Autofac;
using System;

namespace PopulationDatabase
{
    class Demo
    {
        static void NotMain(string[] args)
        {
            var db = OrdinaryDatabase.Instance;

            // works just fine while you're working with a real database.
            var city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
