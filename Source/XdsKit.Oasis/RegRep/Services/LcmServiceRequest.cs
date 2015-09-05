using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Protocols;

namespace XdsKit.Oasis.RegRep.Services
{
    public abstract class LcmServiceRequest : RegistryRequest
    {
        protected LcmServiceRequest()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("lcm", Namespaces.Lcm), 
                new XmlQualifiedName("rs", Namespaces.Rs), 
                new XmlQualifiedName("rim", Namespaces.Rim)
            });
        }
    }
}
