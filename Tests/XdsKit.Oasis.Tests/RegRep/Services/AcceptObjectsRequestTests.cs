using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests.RegRep.Services
{
    [TestFixture]
    public class AcceptObjectsRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<AcceptObjectsRequest>("Resources.Services.AcceptObjectsRequest_Test01.xml");

            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", request.Id);
            Assert.AreEqual("Shortest request in ebRs", request.Comment);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7b", request.CorrelationId);
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Services.AcceptObjectsRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<AcceptObjectsRequest>();
            list.DeepEquals(list2);
        }

        public AcceptObjectsRequest Build_Test01()
        {
            var item = new AcceptObjectsRequest
            {
                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Comment = "Shortest request in ebRs",
                CorrelationId = "urn:xdskit:com:c7ptmx37tfbcwy8ky7b"
            };
            return item;
        }
    }
}
