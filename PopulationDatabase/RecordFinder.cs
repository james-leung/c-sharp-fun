using System;
using System.Collections.Generic;
using System.Text;

namespace PopulationDatabase
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += OrdinaryDatabase.Instance.GetPopulation(name);
            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetPopulation(name);
            return result;
        }
    }
}
