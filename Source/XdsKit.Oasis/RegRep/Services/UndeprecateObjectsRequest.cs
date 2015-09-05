using System.Collections.Generic;
using System.Xml.Serialization;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace = Namespaces.Lcm)]
    public class UndeprecateObjectsRequest : ObjectStatusRequest
    { }
}
