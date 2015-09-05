using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Protocols;

namespace XdsKit.Oasis.Tests.RegRep.Protocols
{
    [TestFixture]
    public class RegistryRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<RegistryRequest>("Resources.Protocols.RegistryRequest_Test01.xml");
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", request.Id);
            Assert.AreEqual("This is a comment", request.Comment);

            Assert.AreEqual(4, request.Slots.Count);
            OasisAssert.Slot(request.Slots[0], "creationTime", "urn:xdskit:com:c7ptmx37tfbcwy8ky7b", new[] { "2015-01-01" });
            OasisAssert.Slot(request.Slots[1], "languageCode", "urn:xdskit:com:c7ptmx37tfbcwy8ky7c", new[] { "en-US", "en-GB", "en-AU" });
            OasisAssert.Slot(request.Slots[2], "serviceStartTime", "", new[] { "2015-01-01T09:00:00" });
            OasisAssert.Slot(request.Slots[3], "serviceStopTime", "", new[] { "2015-01-01T21:00:00" });
        }
        
        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Protocols.RegistryRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryRequest>();
            list.DeepEquals(list2);
        }

        private RegistryRequest Build_Test01()
        {
            var request = new RegistryRequest
            {
                Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Comment="This is a comment",
                Slots = new List<Slot>
                {
                    new Slot
                    {
                        Name="creationTime",
                        Type = "urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                        Values = new List<string> { "2015-01-01" }
                    },
                    new Slot
                    {
                        Name="languageCode",
                        Type = "urn:xdskit:com:c7ptmx37tfbcwy8ky7c",
                        Values = new List<string> { "en-US", "en-GB", "en-AU" }
                    },
                    new Slot
                    {
                        Name="serviceStartTime",
                        Values = new List<string> { "2015-01-01T09:00:00" }
                    },
                    new Slot
                    {
                        Name="serviceStopTime",
                        Values = new List<string> { "2015-01-01T21:00:00" }
                    }
                }
            };

            return request;
        }
    }
}
