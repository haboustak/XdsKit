using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class ExtrinsicObject : RegistryObject
    {
        [XmlElement("ContentVersionInfo")]
        public VersionInfo ContentVersionInfo { get; set; }

        [XmlAttribute("mimeType")]
        public string MimeType { get; set; }

        [XmlAttribute("isOpaque")]
        public bool IsOpaque { get; set; }
    }
}