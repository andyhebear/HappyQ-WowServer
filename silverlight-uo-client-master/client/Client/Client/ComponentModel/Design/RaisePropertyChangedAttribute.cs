using System;

namespace Client.ComponentModel.Design
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RaisePropertyChangedAttribute : Attribute
    {
        private readonly string[] _properties;

        public string[] Properties
        {
            get { return _properties; }
        }

        public RaisePropertyChangedAttribute(params string[] properties)
        {
            _properties = properties;
        }
    }
}
