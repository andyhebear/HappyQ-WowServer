using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Persistence
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ColumnAttribute : Attribute
    {
        private readonly string _name;

        public string Name
        {
            get { return _name; }
        }

        public ColumnAttribute(string name)
        {
            _name = name;
        }
    }
}
