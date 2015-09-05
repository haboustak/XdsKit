using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
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
    }
}
