using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class VersionInfo
    {
        [XmlAttribute("versionName"), DefaultValue("1.1")]
        public string VersionName { get; set; }

        public bool VersionNameSpecified
        {
            get { return VersionName.Specified("1.1"); }
        }

        [XmlAttribute("comment")]
        public string Comment { get; set; }
    }
}
