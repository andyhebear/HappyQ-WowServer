using System;
using System.ComponentModel;

namespace Client
{
    public static class ObjectConverterter
    {
        public static bool TryConvert<TConvertFrom, UConvertTo>(TConvertFrom convertFrom, out UConvertTo convertTo)
        {
            object to;
            bool converted = TryConvert(typeof(TConvertFrom), convertFrom, typeof(UConvertTo), out to);

            convertTo = (UConvertTo)to;

            return converted;
        }

        public static bool TryConvert(Type convertFrom, object from, Type convertTo, out object to)
        {
            to = null;
            bool converted = false;

            if(convertFrom == convertTo)
            {
                to = from;
                return true;
            }

            if (from != null && convertTo.IsEnum)
            {
                to = Enum.Parse(convertTo, from.ToString(), true);
                return true;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(convertFrom);

            if (converter.CanConvertTo(convertTo))
            {
                to = converter.ConvertTo(from, convertTo);
                converted = true;
            }
            else
            {
                converter = TypeDescriptor.GetConverter(convertTo);

                if (converter.CanConvertFrom(convertFrom))
                {
                    to = converter.ConvertFrom(from);
                    converted = true;
                }
            }

            return converted;
        }
    }
}
