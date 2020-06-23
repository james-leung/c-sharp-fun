using System;
using System.Collections.Generic;

namespace SalaryCalculatorNS
{
    class Program
    {
        static void Main(string[] args)
        {
            DeveloperReport dev1 = new DeveloperReport { Id = 1, Name = "Richard", Level = "Junior developer", HourlyRate = 50, WorkingHours = 160 };
            DeveloperReport dev2 = new DeveloperReport { Id = 2, Name = "Ian", Level = "Senior developer", HourlyRate = 70, WorkingHours = 160 };
            DeveloperReport dev3 = new DeveloperReport { Id = 3, Name = "Aaron", Level = "Software Engineer", HourlyRate = 60, WorkingHours = 168 };

            var devCalculations = new SalaryCalculator(new List<BaseSalaryCalculator> { new JuniorDevSalaryCalculator(dev1), new SeniorDevSalaryCalculator(dev2), new JuniorDevSalaryCalculator(dev3) });

            Console.WriteLine($"The total salary of the employees is ${devCalculations.CalculateTotalSalary()}");
        }
    }
}
