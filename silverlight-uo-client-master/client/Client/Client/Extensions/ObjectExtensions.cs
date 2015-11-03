using System;

namespace Client
{
    public static class ObjectExtensions
    {
        public static object ConvertTo(this object obj, Type convertTo)
        {
            if (obj == null)
            {
                if (convertTo.IsNullableType() || convertTo.IsByRef)
                    return null;

                throw new InvalidCastException(string.Format("Unable to case null to {1}'.", obj.GetType(), convertTo));
            }

            object converted = null;

            if (!ObjectConverterter.TryConvert(obj.GetType(), obj, convertTo, out converted))
            {
                throw new InvalidCastException(string.Format("Unable to cast '{0}' to {1}'.", obj.GetType(), convertTo));
            }

            return converted;
        }

        public static bool TryConvertTo(this object obj, Type convertTo, out object outValue)
        {
            outValue = null;

            if (obj == null)
            {
                return convertTo.IsNullableType();
            }

            object converted;

            if (!ObjectConverterter.TryConvert(obj.GetType(), obj, convertTo, out converted))
            {
                return false;
            }

            outValue = converted;
            return true;
        }

        public static T ConvertTo<T>(this object obj)
        {
            return (T)ConvertTo(obj, typeof(T));
        }

        public static bool TryConvertTo<T>(this object obj, out T outValue)
        {
            object o;
            bool success = TryConvertTo(obj, typeof(T), out o);
            outValue = (T)o;

            return success;
        }
    }
}
