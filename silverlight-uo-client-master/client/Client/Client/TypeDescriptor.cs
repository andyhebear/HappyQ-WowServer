using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client
{
    public static class TypeDescriptor
    {
        private static readonly Dictionary<Type, TypeConverter> _cache =
            new Dictionary<Type, TypeConverter>();

        /// <summary>
        /// Returns a type converter for the specified type.
        /// </summary>
        /// <param name="type">The System.Type of the target component.</param>
        /// <returns>A System.ComponentModel.TypeConverter for the specified type.</returns>
        public static TypeConverter GetConverter(Type type)
        {
            TypeConverter converter;

            if (!_cache.TryGetValue(type, out converter))
            {
                object[] customAttributes = type.GetCustomAttributes(typeof(TypeConverterAttribute), true);

                if (customAttributes.Length == 0) return new TypeConverter();

                converter = CreateConverter(((TypeConverterAttribute)customAttributes[0]).ConverterTypeName);
                _cache[type] = converter;
            }

            return converter;
        }

        private static TypeConverter CreateConverter(string converterTypeName)
        {
            return (Activator.CreateInstance(Type.GetType(converterTypeName)) as TypeConverter);
        }
    }
}
