using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Serialization;

namespace Client.ComponentModel.Design
{
    public abstract class NotifierBase : INotifyPropertyChanged, IDisposable
    {
        [XmlIgnore]
        private readonly Dictionary<string, object> _properties;
        [XmlIgnore]
        private readonly Dictionary<string, string[]> _raiseChangedProperties;

        public event PropertyChangedEventHandler PropertyChanged;

        protected NotifierBase()
        {
            _properties = new Dictionary<string, object>();
            _raiseChangedProperties = new Dictionary<string, string[]>();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        protected virtual T Get<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            return Get<T>(propertyName);
        }

        protected virtual bool Set<T>(Expression<Func<T>> propertyExpression, T value)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            return Set<T>(propertyName, value);
        }

        protected virtual T Get<T>(string propertyName)
        {
            EnsurePropertyInitialized(propertyName);
            return (T)_properties[propertyName];
        }

        protected virtual bool Set<T>(string propertyName, T value)
        {
            EnsurePropertyInitialized(propertyName);

            object newValue = value;
            object oldValue = (T)_properties[propertyName];

            if (oldValue != newValue)
            {
                _properties[propertyName] = newValue;

                OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                string[] raiseChanges;

                if (_raiseChangedProperties.TryGetValue(propertyName, out raiseChanges))
                {
                    RaisePropertyChanged(raiseChanges);
                }

                return true;
            }

            return false;
        }

        protected void RaisePropertyChanged(params Expression<Func<object>>[] propertyExpressions)
        {
            for (int i = 0; i < propertyExpressions.Length; i++)
            {
                Expression<Func<object>> propertyExpression = propertyExpressions[i];

                OnPropertyChanged(this, new PropertyChangedEventArgs(PropertySupport.ExtractPropertyName<object>(propertyExpression)));
            }
        }

        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            for (int i = 0; i < propertyNames.Length; i++)
            {
                OnPropertyChanged(this, new PropertyChangedEventArgs(propertyNames[i]));
            }
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }

        private void InitializeProperty(PropertyInfo info, bool initialize)
        {
            Type underlyingType = Nullable.GetUnderlyingType(info.PropertyType);

            if (!info.PropertyType.IsValueType || (underlyingType != null))
            {
                _properties.Add(info.Name, null);

                if (initialize)
                {
                    if (info.PropertyType.Equals(typeof(string)))
                    {
                        Set(info.Name, "");
                    }
                    else if (!info.PropertyType.IsAbstract &&
                             info.PropertyType.GetConstructor(Type.EmptyTypes) != null)
                    {
                        Set(info.Name, Activator.CreateInstance(info.PropertyType));
                    }
                    else
                    {
                        Set(info.Name, Activator.CreateInstance(underlyingType));
                    }
                }
            }
            else
            {
                _properties.Add(info.Name, Activator.CreateInstance(info.PropertyType));
            }
        }

        private void EnsurePropertyInitialized(string propertyName)
        {
            if (!_properties.ContainsKey(propertyName))
            {
                PropertyInfo info = GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (info == null)
                {
                    throw new Exception(string.Format("Cannot find property '{0}'", propertyName));
                }

                InitializeProperty(info, false);

                object[] defaultValue = info.GetCustomAttributes(typeof(DefaultValueAttribute), false);

                if (defaultValue.Length > 0)
                {
                    _properties[propertyName] = ((DefaultValueAttribute)defaultValue[0]).Value;
                }
            }
        }
    }
}
