using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class LocalizedString
    {
        [XmlAttribute("lang", Namespace=Namespaces.Xml), DefaultValue("en-US")]
        public string Language { get; set; }

        [XmlIgnore]
        public bool LanguageSpecified
        {
            get { return Language.Specified("en-US"); }
        }

        [XmlAttribute("charset"), DefaultValue("UTF-8")]
        public string Charset { get; set; }

        public bool CharsetSpecified
        {
            get { return Charset.Specified("UTF-8"); }
        }
        [XmlAttribute("value")]
        public string Value { get; set; }

        public LocalizedString()
        {
            Language = "en-US";
            Charset = "UTF-8";
        }
    }
}
