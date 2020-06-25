using Autofac;
using NUnit.Framework;
using System;

namespace PopulationDatabase
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SingletonTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(34900000));
        }

        [Test]
        public void AutofacTest()
        {
            // DI Container
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();

            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
                var tp = rf.GetTotalPopulation(new[] { "Tokyo", "Mexico City" });
                Console.WriteLine($"The total population of  Tokyo and Mexico City is {tp}.");
                Assert.That(tp, Is.EqualTo(50600000));
            }
        }
    }
}
