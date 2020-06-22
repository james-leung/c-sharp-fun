using System;
using System.Collections.Generic;
using System.Text;

namespace PersonBuilder2
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public class Builder : PersonBuilder
        {

        }
        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
}
