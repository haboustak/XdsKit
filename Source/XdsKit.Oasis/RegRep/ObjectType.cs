using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.RegRep
{
    public class ObjectType : UriEnumeration
    {
        public ObjectType(string uri)
            : base(uri)
        { }

        public static ObjectType RegistryObject = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject");
        public static ObjectType QueryDefinition = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:QueryDefinition");
        public static ObjectType Association = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Association");
        public static ObjectType AuditableEvent = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:AuditableEvent");
        public static ObjectType Classification = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Classification");
        public static ObjectType ExternalIdentifier = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExternalIdentifier");
        public static ObjectType ExternalLink = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExternalLink");
        public static ObjectType Notification = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Notification");
        public static ObjectType Party = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Party");
        public static ObjectType Organization = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Organization");
        public static ObjectType Person = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Person");
        public static ObjectType Subscription = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Subscription");
        public static ObjectType TaxonomyElement = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:TaxonomyElement");
        public static ObjectType ClassificationNode = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ClassificationNode");
        public static ObjectType ClassificationScheme = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ClassificationScheme");
        public static ObjectType Federation = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Federation");
        public static ObjectType Registry = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Registry");
        public static ObjectType RegistryPackage = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage");
        public static ObjectType Register = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Register");
        public static ObjectType Role = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Role");
        public static ObjectType Service = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Service");
        public static ObjectType ServiceEndpoint = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ServiceEndpoint");
        public static ObjectType ServiceBinding = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ServiceBinding");
        public static ObjectType ServiceInterface = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ServiceInterface");
        public static ObjectType ExtrinsicObject = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject");
        public static ObjectType Comment = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:Comment");
        public static ObjectType Xml = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML");
        public static ObjectType Xslt = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XSLT");
        public static ObjectType XmlSchema = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XMLSchema");
        public static ObjectType Schematron = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:Schematron");
        public static ObjectType XHtml = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XHTML");
        public static ObjectType XForm = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XHTML:XForm");
        public static ObjectType Xacml = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XACML");
        public static ObjectType Policy = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XACML:Policy");
        public static ObjectType PolicySet = new ObjectType("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:ExtrinsicObject:XML:XACML:PolicySet");

    }
}
