using System.Xml.Serialization;

namespace XdsKit
{
    public static partial class ObjectExtensions
    {
        public static XmlRootAttribute XmlRoot(this object item)
        {
            if (item == null) return null;
            return item.GetType().XmlRoot();
        }
    }
}
