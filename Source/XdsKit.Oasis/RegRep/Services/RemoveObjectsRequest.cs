using System.Collections.Generic;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class RemoveObjectsRequest : LcmServiceRequest
    {
        private DeletionScope _deletionScope;

        [XmlAttribute("deletionScope")]
        public string DeletionScopeValue { get; set; }

        [XmlIgnore]
        public bool DeletionScopeValueSpecified
        {
            get { return DeletionScope != DeletionScope.DeleteAll; }
        }

        [XmlIgnore]
        public DeletionScope DeletionScope
        {
            get { return _deletionScope ?? (_deletionScope = UriEnumeration.Parse(DeletionScopeValue) as DeletionScope); }
            set
            {
                _deletionScope = null;
                DeletionScopeValue = value != null ? value.Uri : null;
            }
        }

        [XmlElement("AdhocQuery", Namespace = Namespaces.Rim)]
        public AdhocQuery Query { get; set; }

        [XmlArray("ObjectRefList", Namespace = Namespaces.Rim)]
        public List<ObjectRef> Objects { get; set; }

        public RemoveObjectsRequest()
        {
            DeletionScope = DeletionScope.DeleteAll;
        }
    }
}
