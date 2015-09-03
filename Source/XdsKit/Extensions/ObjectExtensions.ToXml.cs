using System.Xml.Linq;
using System.Xml.Serialization;

namespace XdsKit
{
    public static partial class ObjectExtensions
    {
        public static XDocument ToXml(this object item)
        {
            if (item == null) return null;

            var response = new XDocument();
            using (var writer = response.CreateWriter())
            {
                var xsn = new XmlSerializerNamespaces();
                XmlRootAttribute root = item.XmlRoot();
                if (root != null && !string.IsNullOrEmpty(root.Namespace)) xsn.Add("", root.Namespace);
                var xmlWriter = new XmlSerializer(item.GetType());
                xmlWriter.Serialize(writer, item, xsn);
            }
            return response;
        }
    }
}
