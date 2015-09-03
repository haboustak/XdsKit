using System;
using System.Xml.Serialization;

namespace XdsKit
{
    public static class TypeExtensions
    {
        public static XmlRootAttribute XmlRoot(this Type item)
        {
            if (item == null) return null;
            return (XmlRootAttribute)Attribute.GetCustomAttribute(item, typeof(XmlRootAttribute));
        }
    }
}
