using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Models
{
    [XmlRoot(Namespace = Namespaces.Rim)]
    public class RegistryObjectList
    {
        // Core Information Model
        [XmlElement("RegistryPackage")]
        public List<RegistryPackage> RegistryPackages { get; set; }

        [XmlElement("ExtrinsicObject")]
        public List<ExtrinsicObject> ExtrinsicObjects { get; set; }

        [XmlElement("ExternalLink")]
        public List<ExternalLink> ExternalLinks { get; set; }

        [XmlElement("ExternalIdentifier")]
        public List<ExternalIdentifier> ExternalIdentifiers { get; set; }

        // Classification Model
        [XmlElement("ClassificationScheme")]
        public List<ClassificationScheme> ClassificationSchemes { get; set; }

        [XmlElement("ClassificationNode")]
        public List<ClassificationNode> ClassificationNodes { get; set; }

        [XmlElement("Classification")]
        public List<Classification> Classifications { get; set; }

        // Provenance Information Model
        [XmlElement("Person")]
        public List<Person> Persons { get; set; }

        [XmlElement("User")]
        public List<User> Users { get; set; }

        [XmlElement("Organization")]
        public List<Organization> Organizations { get; set; }

        // Event Information Model
        [XmlElement("Subscription")]
        public List<Subscription> Subscriptions { get; set; }

        [XmlElement("Notification")]
        public List<Notification> Notifications { get; set; }

        [XmlElement("AuditableEvent")]
        public List<AuditableEvent> AuditableEvents { get; set; }

        [XmlElement("AdhocQuery")]
        public List<AdhocQuery> AdhocQueries { get; set; }

        // Service Information Model
        [XmlElement("Service")]
        public List<Service> Services { get; set; }

        [XmlElement("ServiceBinding")]
        public List<ServiceBinding> ServiceBindings { get; set; }

        [XmlElement("SpecificationLink")]
        public List<SpecificationLink> SpecificationLinks { get; set; }

        // Cooperating Registry Information Model
        [XmlElement("Registry")]
        public List<Registry> Registries { get; set; }

        [XmlElement("Federation")]
        public List<Federation> Federations { get; set; }

        // External References
        [XmlElement("ObjectRef")]
        public List<ObjectRef> ObjectReferences { get; set; }

        // Association Model
        [XmlElement("Association")]
        public List<Association> Associations { get; set; }

        [XmlNamespaceDeclarations] 
        public XmlSerializerNamespaces xmlns;

        public RegistryObjectList()
        {
            xmlns = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("rim", Namespaces.Rim) 
            });
        }
    }
}