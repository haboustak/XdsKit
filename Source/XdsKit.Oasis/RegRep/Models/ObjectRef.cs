using System.ComponentModel;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class ObjectRef : Identifiable
    {
        [XmlAttribute("createReplica"), DefaultValue(false)]
        public bool CreateReplica { get; set; }

        [XmlIgnore]
        public bool CreateReplicaSpecified
        {
            get { return CreateReplica; }
        }
    }
}
