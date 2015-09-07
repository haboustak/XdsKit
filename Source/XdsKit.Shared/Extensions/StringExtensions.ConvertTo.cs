using System;
using System.ComponentModel;
using System.Globalization;

namespace XdsKit
{
    public static partial class StringExtensions
    {
        public static T ConvertTo<T>(this string value, T defaultValue = default(T), IFormatProvider formatProvider = null)
        {
            var destinationType = typeof (T);
            var converter = TypeDescriptor.GetConverter(destinationType);
            if (converter != null && converter.CanConvertFrom(typeof(string)))
                return (T)converter.ConvertFrom(value);

            return (T)Convert.ChangeType(value, destinationType, formatProvider ?? CultureInfo.CurrentCulture);

        }
    }
}
