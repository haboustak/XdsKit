using System;
using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class CooperatingRegistryModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.CooperatingRegistryModel_Test01.xml");

            Assert.AreEqual(2, list.Registries.Count);
            OasisAssert.Registry(list.Registries[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7a", "urn:xdskit:com:c7ptmx37tfbcwy8ky7b", "3.0",
                new TimeSpan(2, 0, 0), new TimeSpan(2, 0, 0, 0), "registryLite");
            Assert.AreEqual(true, list.Registries[0].ReplicationSyncLatencyValueSpecified);
            Assert.AreEqual(true, list.Registries[0].CatalogingLatencyValueSpecified);
            OasisAssert.Registry(list.Registries[1],
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
            OasisAssert.Association(list.Associations[0], "", AssociationType.HasFederationMember, "urn:xdskit:com:c7ptmx37tfbcwy8ky7g", "urn:xdskit:com:c7ptmx37tfbcwy8ky7a");
            OasisAssert.Association(list.Associations[1], "", AssociationType.HasFederationMember, "urn:xdskit:com:c7ptmx37tfbcwy8ky7g", "urn:xdskit:com:c7ptmx37tfbcwy8ky7d");

        }


        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.CooperatingRegistryModel_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test01()
        {
            var list = new RegistryObjectList
            {
                Registries = new List<Registry>
                {
                    new Registry
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                      Operator="urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                      SpecificationVersion="3.0",
                      ReplicationSyncLatency="PT2H".AsTimeSpan(),
                      CatalogingLatency="P2D".AsTimeSpan(),
                      ConformanceProfile="registryLite",
                    },
                    new Registry
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7d",
                        Operator="urn:xdskit:com:c7ptmx37tfbcwy8ky7e",
                        SpecificationVersion="3.0",
                        ConformanceProfile="registryFull",
                    }
                },
                Federations = new List<Federation>
                {
                    new Federation
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7g",
                        ReplicationSyncLatency = "PT2H".AsTimeSpan()
                    },
                    new Federation
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7h"
                    }
                },
                Associations = new List<Association>
                {
                    new Association
                    {
                        AssociationType = AssociationType.HasFederationMember,
                        Source="urn:xdskit:com:c7ptmx37tfbcwy8ky7g",
                        Target="urn:xdskit:com:c7ptmx37tfbcwy8ky7a"
                    },
                    new Association
                    {
                        AssociationType = AssociationType.HasFederationMember,
                        Source="urn:xdskit:com:c7ptmx37tfbcwy8ky7g",
                        Target="urn:xdskit:com:c7ptmx37tfbcwy8ky7d"
                    }
                }
            };

            return list;
        }

    }
}
