using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class RegistryPackage : RegistryObject
    {
        [XmlElement("RegistryObjectList")]
        public RegistryObjectList RegistryObjects { get; set; }
    }
}