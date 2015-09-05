using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests.RegRep.Services
{
    [TestFixture]
    public class AdhocQueryRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<AdhocQueryRequest>("Resources.Services.AdhocQueryRequest_Test01.xml");
            OasisAssert.ResponseOption(request.ResponseOption, ReturnType.LeafClass, true);

            OasisAssert.AdhocQuery(request.Query, "urn:xdskit:com:c7ptmx37tfbcwy8ky7a");
            Assert.AreEqual(5, request.Query.Slots.Count);
            OasisAssert.Slot(request.Query.Slots[0], "$XDSDocumentEntryPatientId", "", new[] { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" });
            OasisAssert.Slot(request.Query.Slots[1], "$XDSDocumentEntryStatus", "", new[] { "('urn:oasis:names:tc:ebxml-egrep:ResponseStatusType:Approved')" });
            OasisAssert.Slot(request.Query.Slots[2], "$XDSDocumentEntryCreationTimeFrom", "", new[] { "200412252300" });
            OasisAssert.Slot(request.Query.Slots[3], "$XDSDocumentEntryCreationTimeTo", "", new[] { "200501010800" });
            OasisAssert.Slot(request.Query.Slots[4], "$XDSDocumentEntryHealthcareFacilityTypeCode", "", new[] { "('Emergency Department')" });
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Services.AdhocQueryRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<AdhocQueryRequest>();
            list.DeepEquals(list2);
        }

        public AdhocQueryRequest Build_Test01()
        {
            var item = new AdhocQueryRequest
            {
                ResponseOption = new ResponseOption
                {
                    ReturnComposedObjects = true,
                    ReturnType = ReturnType.LeafClass
                },
                Query = new AdhocQuery
                {
                    Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                    Slots = new List<Slot>
                    {
                        new Slot
                        {
                            Name = "$XDSDocumentEntryPatientId",
                            Values = new List<string> { "st3498702^^^&1.3.6.1.4.1.21367.2005.3.7&ISO" }
                        },
                        new Slot
                        {
                            Name = "$XDSDocumentEntryStatus",
                            Values = new List<string> { "('urn:oasis:names:tc:ebxml-egrep:ResponseStatusType:Approved')" }
                        },
                        new Slot
                        {
                            Name = "$XDSDocumentEntryCreationTimeFrom",
                            Values = new List<string> { "200412252300" }
                        },
                        new Slot
                        {
                            Name = "$XDSDocumentEntryCreationTimeTo",
                            Values = new List<string> { "200501010800" }
                        },
                        new Slot
                        {
                            Name = "$XDSDocumentEntryHealthcareFacilityTypeCode",
                            Values = new List<string> { "('Emergency Department')" }
                        }
                    }
                }
            };
            return item;
        }
    }
}
