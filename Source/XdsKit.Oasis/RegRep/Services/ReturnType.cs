using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Services
{
    public enum ReturnType
    {
        [XmlEnum("ObjectRef")]
        ObjectRef,

        [XmlEnum("RegistryObject")]
        RegistryObject,

        [XmlEnum("LeafClass")]
        LeafClass,

        [XmlEnum("LeafClassWithRepositoryItem")]
        LeafClassWithRepositoryItem
    }
}
