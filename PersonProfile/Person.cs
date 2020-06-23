using System;
using System.Collections.Generic;
using System.Text;

namespace PersonProfile
{
    public class Person
    {
        public string StreetAddress, PostalCode, City;

        public string CompanyName, Position;

        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, " +
                $"{nameof(PostalCode)}: {PostalCode}, " +
                $"{nameof(City)}: {City}, " +
                $"{nameof(CompanyName)}: {CompanyName}, " +
                $"{nameof(Position)}: {Position}, " +
                $"{nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
}
