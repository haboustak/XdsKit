using System.IO;
using System.Xml.Serialization;

namespace XdsKit
{
    public static partial class StringExtensions
    {
        public static T FromXml<T>(this string xml)
        {
            using (TextReader reader = new StringReader(xml))
            {
                XmlRootAttribute root = typeof(T).XmlRoot();
                var serializer = new XmlSerializer(typeof(T), root);
                return (T)serializer.Deserialize(reader);
            }        
        }
    }
}
