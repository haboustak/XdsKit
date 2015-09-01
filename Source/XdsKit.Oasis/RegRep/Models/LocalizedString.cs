using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class LocalizedString
    {
        [XmlAttribute("lang"), DefaultValue("en-US")]
        public string Language { get; set; }

        [XmlAttribute("charset"), DefaultValue("UTF-8")]
        public string Charset { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        public LocalizedString()
        {
            Language = "en-US";
            Charset = "UTF-8";
        }
    }
}
