using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder
{
    public class CodeBuilder
    {
        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>();
        private readonly string _className;

        public CodeBuilder(string className)
        {
            _className = className;
        }
        public CodeBuilder AddField(string field, string type)
        {
            _fields.Add(field, type);
            return this;
        }

        public override string ToString()
        {
            string output = $"public class {_className} \n{{ \n";
            foreach (var field in _fields.Keys)
            {
                output += $"  public {_fields[field]} {field}; \n";
            }
            return output + $"}}";
        }
    }
}
