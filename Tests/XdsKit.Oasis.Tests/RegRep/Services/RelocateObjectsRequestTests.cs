using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests.RegRep.Services
{
    [TestFixture]
    public class RelocateObjectsRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<RelocateObjectsRequest>("Resources.Services.RelocateObjectsRequest_Test01.xml");

            OasisAssert.AdhocQuery(request.Query, "urn:xdskit:com:c7ptmx37tfbcwy8ky7b");
            Assert.AreEqual(1, request.Query.Slots.Count);
            OasisAssert.Slot(request.Query.Slots[0], "$XDSDocumentEntryPatientId", "", new[] { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" });

            OasisAssert.ObjectRef(request.SourceRegistry, "urn:xdskit:com:c7ptmx37tfbcwy8ky7c");
            OasisAssert.ObjectRef(request.DestinationRegistry, "urn:xdskit:com:c7ptmx37tfbcwy8ky7d");
            OasisAssert.ObjectRef(request.OwnerAtSource, "urn:xdskit:com:c7ptmx37tfbcwy8ky7e");
            OasisAssert.ObjectRef(request.OwnerAtDestination, "urn:xdskit:com:c7ptmx37tfbcwy8ky7f");
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Services.RelocateObjectsRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RelocateObjectsRequest>();
            list.DeepEquals(list2);
        }

        public RelocateObjectsRequest Build_Test01()
        {
            var item = new RelocateObjectsRequest
            {
                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Comment = "This relocates",
                Query = new AdhocQuery
                {
                    Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                    Slots = new List<Slot>
                    {
                        new Slot
                        {
                            Name = "$XDSDocumentEntryPatientId",
                            Values = new List<string> { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" }
                        }
                    }

                },
                SourceRegistry = new ObjectRef { Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7c" },
                DestinationRegistry = new ObjectRef { Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7d" },
                OwnerAtSource = new ObjectRef { Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7e" },
                OwnerAtDestination = new ObjectRef { Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7f" }
            };
            return item;
        }
    }
}
