using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests.RegRep.Services
{
    [TestFixture]
    public class RemoveObjectsRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<RemoveObjectsRequest>("Resources.Services.RemoveObjectsRequest_Test01.xml");

            OasisAssert.AdhocQuery(request.Query, "urn:xdskit:com:c7ptmx37tfbcwy8ky7a");
            Assert.AreEqual(1, request.Query.Slots.Count);
            OasisAssert.Slot(request.Query.Slots[0], "$XDSDocumentEntryPatientId", "", new[] { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" });

            Assert.AreEqual(4, request.Objects.Count);
            OasisAssert.ObjectRef(request.Objects[0], "urn:xdskit:com:c7ptmx37tfbcwy8ky7b");
            OasisAssert.ObjectRef(request.Objects[1], "urn:xdskit:com:c7ptmx37tfbcwy8ky7c");
            OasisAssert.ObjectRef(request.Objects[2], "urn:xdskit:com:c7ptmx37tfbcwy8ky7d");
            OasisAssert.ObjectRef(request.Objects[3], "urn:xdskit:com:c7ptmx37tfbcwy8ky7e");
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Services.RemoveObjectsRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RemoveObjectsRequest>();
            list.DeepEquals(list2);
        }

        public RemoveObjectsRequest Build_Test01()
        {
            var item = new RemoveObjectsRequest
            {
                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Comment = "Remove these documents",
                Query = new AdhocQuery
                {
                    Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                    Slots = new List<Slot>
                    {
                        new Slot
                        {
                            Name = "$XDSDocumentEntryPatientId",
                            Values = new List<string> { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" }
                        }
                    }

                },
                Objects = new List<ObjectRef>
                {
                    new ObjectRef {Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7b"},
                    new ObjectRef {Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7c"},
                    new ObjectRef {Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7d"},
                    new ObjectRef {Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7e"},
                }
            };
            return item;
        }
    }
}
