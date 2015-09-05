using System;
using System.ComponentModel;
using System.Reflection;

namespace XdsKit
{
    public static partial class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            MemberInfo[] infos = value.GetType().GetMember(value.ToString());
            if (infos.Length == 0) return null;

            object[] attributes = infos[0].GetCustomAttributes(typeof (DescriptionAttribute), false);
            return (attributes.Length > 0)
                ? ((DescriptionAttribute) attributes[0]).Description
                : null;
        }
    }
}
