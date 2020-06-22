using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PersonBuilder2
{
    public class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
        public PersonBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
        public PersonBuilder WorksAs(string job)
        {
            person.Position = job;
            return this;
        }
    }
}
