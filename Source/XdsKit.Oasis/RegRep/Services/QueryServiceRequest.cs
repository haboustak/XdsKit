
using System.Xml;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Protocols;

namespace XdsKit.Oasis.RegRep.Services
{
    public abstract class QueryServiceRequest : RegistryRequest
    {
        protected QueryServiceRequest()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("query", Namespaces.Query), 
                new XmlQualifiedName("rs", Namespaces.Rs), 
                new XmlQualifiedName("rim", Namespaces.Rim)
            });
        }
    }
}
