using System.Xml;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public abstract class XdsEntry<T>
        where T : RegistryObject
    {
        public string UniqueId { get; set; }
        
        public string EntryUuid { get; set; }

        public string Comments { get; set; }

        public string HomeCommunityId { get; set; }

        public string Title { get; set; }

        public abstract T ToRegistryObject();
    }
}
