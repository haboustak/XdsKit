using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlType(Namespace = Namespaces.Rim)]
    public class ObjectRef : Identifiable
    {
        [XmlAttribute("createReplica"), DefaultValue(false)]
        public bool CreateReplica { get; set; }
    }
}
