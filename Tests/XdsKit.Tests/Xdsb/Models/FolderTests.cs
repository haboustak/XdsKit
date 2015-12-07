using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Xdsb.Models;

namespace XdsKit.Tests.Xdsb.Models
{
    [TestFixture]
    public class FolderTests
    {
        [Test]
        public void Should_Build_Folder_Test01()
        {
            var folder = new Folder
            {
                AvailabilityStatus = StatusType.Approved,
                Codes = new List<FolderCode>
                {
                    new FolderCode
                    {
                        Value = "42",
                        DisplayName="Blue Folder",
                        CodeSystemId = "1.2.3.4.5.6.7"
                    },
                    new FolderCode
                    {
                        Value = "99",
                        DisplayName="Secured Folder",
                        CodeSystemId = "7.6.5.4.3.2.1"
                    }
                },
                Comments = "This folder contains all XdsKit documents",
                EntryUuid = "Folder01",
                HomeCommunityId = "urn:oid:1.2.3.4.5.6.7",
                LastUpdateTime = new DateTimeOffset(2015, 9, 1, 8, 55, 00, TimeSpan.Zero),
                LimitedMetadata = true,
                PatientId = new XdsIdentifier
                {
                    Id = "MRN123456789",
                    UniversalId = "8"
                },
                Title = "XdsKit Documents",
                UniqueId = "1.2.3.4.5.6.7"
            };

            RegistryPackage package = folder.ToRegistryObject();
            package.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Xdsb.Folder_Test01.xml")));
        }
    }
}
