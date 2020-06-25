using System;
using System.Collections.Generic;
using System.Text;

namespace PersonFactory
{

    public class PersonFactory
    {
        private int count = 0;
        public Person CreatePerson(string name)
        {
            var person = new Person();

            person.Id = count;
            person.Name = name;
            count++;
            return person;
        }
    }
}
