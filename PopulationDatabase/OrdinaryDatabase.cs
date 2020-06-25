using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using MoreLinq;
using static System.Console;

namespace PopulationDatabase
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();
        private SingletonDatabase()
        {
            capitals = File.ReadAllLines("capitals.txt").Batch(2).ToDictionary(list => list.ElementAt(0).Trim(), list => int.Parse(list.ElementAt(1)));
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static IDatabase Instance => instance.Value;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            WriteLine("Initializing database");

            capitals = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
              )
              .Batch(2)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        // laziness + thread safety
        private static Lazy<OrdinaryDatabase> instance = new Lazy<OrdinaryDatabase>(() =>
        {
            return new OrdinaryDatabase();
        });

        public static IDatabase Instance => instance.Value;
    }
}
