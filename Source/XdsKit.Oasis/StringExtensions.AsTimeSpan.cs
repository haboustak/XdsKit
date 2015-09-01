using System;
using System.Xml;

namespace XdsKit.Oasis
{
    public static class StringExtensions
    {
        public static TimeSpan AsTimeSpan(this string value)
        {
            return AsTimeSpan(value, string.Empty);
        }

        public static TimeSpan AsTimeSpan(this string value, string defaultValue)
        {
            value = string.IsNullOrEmpty(value) ? defaultValue : value;
            try
            {
                if (!string.IsNullOrEmpty(value))
                    return XmlConvert.ToTimeSpan(value);
            }
            catch { }

            return default(TimeSpan);
        }
    }
}
