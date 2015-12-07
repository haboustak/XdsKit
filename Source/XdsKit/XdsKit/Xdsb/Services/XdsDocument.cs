using System.Xml.Serialization;

using XdsKit.Oasis;

namespace XdsKit.Xdsb.Services
{
    [XmlType(Namespace = Namespaces.Xdsb)]
    public class XdsDocument
    {
        [XmlAttribute("id", DataType = "anyURI")]
        public string Id { get; set; }

        [XmlText(DataType = "base64Binary")]
        public byte[] Content { get; set; }
    }
}
