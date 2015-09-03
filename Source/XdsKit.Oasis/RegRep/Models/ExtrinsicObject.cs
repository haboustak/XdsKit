using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class ExtrinsicObject : RegistryObject
    {
        [XmlElement("ContentVersionInfo")]
        public VersionInfo ContentVersionInfo { get; set; }

        [XmlAttribute("mimeType"), DefaultValue("application/octet-stream")]
        public string MimeType { get; set; }

        [XmlIgnore]
        public bool MimeTypeSpecified
        {
            get { return MimeType.Specified("application/octet-stream"); }
        }

        [XmlAttribute("isOpaque"), DefaultValue(false)]
        public bool IsOpaque { get; set; }

        [XmlIgnore]
        public bool IsOpaqueSpecified { get { return IsOpaque; } }
    }
}