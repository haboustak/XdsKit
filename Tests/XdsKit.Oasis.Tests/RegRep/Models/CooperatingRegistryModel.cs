
using System;
using System.Runtime;
using NUnit.Framework;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class CooperatingRegistryModel
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.CooperatingRegistryModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

            Assert.AreEqual(2, list.Registries.Count);
            AssertRegistry(list.Registries[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7a", "urn:xdskit:com:c7ptmx37tfbcwy8ky7b", "3.0",
                new TimeSpan(2, 0, 0), new TimeSpan(1, 0, 0, 0), "registryLite");
            Assert.AreEqual(true, list.Registries[0].ReplicationSyncLatencyValueSpecified);
            Assert.AreEqual(false, list.Registries[0].CatalogingLatencyValueSpecified);
            AssertRegistry(list.Registries[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7d", "urn:xdskit:com:c7ptmx37tfbcwy8ky7e", "3.0",
                new TimeSpan(1, 0, 0, 0), new TimeSpan(1, 0, 0, 0), "registryFull");
            Assert.AreEqual(false, list.Registries[1].ReplicationSyncLatencyValueSpecified);
            Assert.AreEqual(false, list.Registries[1].CatalogingLatencyValueSpecified);

            Assert.AreEqual(2, list.Federations.Count);
            var federation = list.Federations[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7g", federation.Id ?? "");
            Assert.AreEqual(new TimeSpan(2, 0, 0), federation.ReplicationSyncLatency);
            Assert.AreEqual(true, federation.ReplicationSyncLatencyValueSpecified);
            federation = list.Federations[1];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7h", federation.Id ?? "");
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), federation.ReplicationSyncLatency);
            Assert.AreEqual(false, federation.ReplicationSyncLatencyValueSpecified);

            Assert.AreEqual(2, list.Associations.Count);
            AssertAssociation(list.Associations[0],
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:HasFederationMember", "urn:xdskit:com:c7ptmx37tfbcwy8ky7g", "urn:xdskit:com:c7ptmx37tfbcwy8ky7a");
            AssertAssociation(list.Associations[1],
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:HasFederationMember", "urn:xdskit:com:c7ptmx37tfbcwy8ky7g", "urn:xdskit:com:c7ptmx37tfbcwy8ky7d");

        }

        private void AssertRegistry(Registry registry,
            string id, string oper, string specificationVersion, TimeSpan replicationSyncLatency, TimeSpan catalogingLatency, string conformanceProfile)
        {
            Assert.AreEqual(id ?? "", registry.Id ?? "");
            Assert.AreEqual(oper ?? "", registry.Operator ?? "");
            Assert.AreEqual(specificationVersion ?? "", registry.SpecificationVersion ?? "");
            Assert.AreEqual(replicationSyncLatency, registry.ReplicationSyncLatency);
            Assert.AreEqual(catalogingLatency, registry.CatalogingLatency);
            Assert.AreEqual(conformanceProfile ?? "", registry.ConformanceProfile ?? "");
        }

        private void AssertAssociation(Association association, string type, string source, string target)
        {
            Assert.AreEqual(type, association.Type);
            Assert.AreEqual(source, association.Source);
            Assert.AreEqual(target, association.Target);
        }
    }
}
