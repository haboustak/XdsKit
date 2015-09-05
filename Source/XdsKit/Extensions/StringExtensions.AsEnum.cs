using System;
using System.ComponentModel;

namespace XdsKit
{
    public static partial class StringExtensions
    {
        public static T AsEnum<T>(this string value, T defaultValue)
        {
            var type = typeof(T);
            if(!type.IsEnum) return defaultValue;

            foreach (var f in type.GetFields())
            {
                var desc = (DescriptionAttribute)Attribute.GetCustomAttribute(f, typeof (DescriptionAttribute));
                if ((desc != null && desc.Description.Equals(value, StringComparison.OrdinalIgnoreCase)) || 
                    f.Name.Equals(value, StringComparison.OrdinalIgnoreCase))
                    return (T) f.GetValue(null);
            }

            return defaultValue;
        }
    }
}
