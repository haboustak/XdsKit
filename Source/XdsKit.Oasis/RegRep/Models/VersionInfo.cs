using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class VersionInfo
    {
        [XmlAttribute("versionName", DataType = "string")]
        public string VersionName { get; set; }

        [XmlAttribute("comment", DataType = "string")]
        public string Comment { get; set; }
    }
}
