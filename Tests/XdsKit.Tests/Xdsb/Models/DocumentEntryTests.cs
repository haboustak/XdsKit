using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Xdsb.Models;

namespace XdsKit.Tests.Xdsb.Models
{
    [TestFixture]
    public class DocumentEntryTests
    {
        [Test]
        public void Should_Build_Document_Test01()
        {
            var document = new DocumentEntry
            {
                Author = new Author
                {
                    Person = new XdsPerson
                    {
                        GivenName = "First",
                        OwnSurname = "XdsKit",
                        Degree = "MD",
                        Prefix = "Dr"
                    },
                    Institution = new List<XdsOrganization>
                    {
                        new XdsOrganization
                        {
                            Name = "XdsKit Clinic",
                            OrganizationId = "1234567893",
                            UniversalId = "2.16.840.1.113883.4.6"
                        },
                        new XdsOrganization
                        {
                            Name = "Radiology Department"
                        }
                    },
                    Role = new List<string>
                    {
                        "Rendering",
                        "Attending"
                    },
                    Specialty = new List<string>
                    {
                        "Pediatrics",
                        "Cardiology"
                    }
                },
                AvailabilityStatus = StatusType.Approved,
                Class = new ClassCode
                {
                    Value = "11506-3",
                    DisplayName = "Progress Note",
                    CodeSystemId = "2.16.840.1.113883.6.1"
                },
                Comments = "This is a new submission",
                Confidentiality = new List<ConfidentialityCode>
                {
                    new ConfidentialityCode
                    {
                        Value = "N",
                        DisplayName = "Normal",
                        CodeSystemId = "2.16.840.1.113883.5.25"
                    }
                },
                CreationTime = new DateTimeOffset(2015, 12, 4, 4, 11, 00, TimeSpan.Zero),
                EntryUuid = "Document01",
                EventCodes = new List<EventCode>
                {
                    new EventCode
                    {
                        Value = "1",
                        DisplayName = "First Event",
                        CodeSystemId = "1.1.1.1.1"
                    },
                    new EventCode
                    {
                        Value = "2",
                        DisplayName = "Second Event",
                        CodeSystemId = "1.2.1.2.1"
                    }
                },
                Format = new FormatCode
                {
                    Value = "urn:ihe:pcc:xds-ms:2007",
                    DisplayName = "Medical Summaries (XDS-MS)",
                    CodeSystemId = "1.3.6.1.4.1.19376.1.2.3"
                },
                Hash = "da39a3ee5e6b4b0d3255bfef95601890afd80709",
                HealthCareFacilityType = new HealthcareFacilityTypeCode
                {
                    Value = "FC01",
                    DisplayName = "Hospital",
                    CodeSystemId = "1.2.3.4.5.6.123"
                },
                HomeCommunityId = "1.2.3.4",
                LanguageCode = "en-US",
                LegalAuthenticator = new XdsPerson
                {
                    GivenName = "Provider",
                    OwnSurname = "XdsKit",
                    Prefix = "Dr"
                },
                MimeType = "application/pdf",
                PatientId = new XdsIdentifier
                {
                    Id = "XYZPAT01",
                    UniversalId = "9.0.1.2.3"
                },
                PracticeSetting = new PracticeSettingCode
                {
                    Value = "PS01",
                    DisplayName = "Practice Setting",
                    CodeSystemId = "1.2.3.4.5.6"
                },
                RepositoryUniqueId = "5.4.3.2.1.0",
                ServiceStartTime = new DateTimeOffset(2015, 12, 4, 4, 27, 00, TimeSpan.Zero),
                ServiceStopTime = new DateTimeOffset(2015, 12, 4, 5, 47, 00, TimeSpan.Zero),
                Size = 1024,
                SourcePatientId = new XdsIdentifier
                {
                    Id = "SP00001102",
                    UniversalId = "0.1.2.3.4"
                },
                SourcePatientInfo = new List<string>
                {
                    "PID-3|SP00001102^^^&amp;0.1.2.3.4&amp;ISO",
                    "PID-5|Patient^XdsKit",
                    "PID-7|1990011",
                    "PID-8|M",
                    "PID-11|123 Sesame Street^^New York^NY^11501"
                },
                Title = "XdsKit Progress Note",
                Type = new DocumentTypeCode
                {
                    Value = "NOTE",
                    DisplayName = "Progress Note"
                },
                UniqueId = "1.2.3.4.5.6.78901.2345.6.7",
                Uri = "http://google.com",
                ReferenceIds = new List<XdsReferenceIdentifier>
                {
                    new XdsReferenceIdentifier
                    {
                         Id = "LB0001",
                         IdType = "urn:ihe:iti:xds:2013:accession",
                         UniversalId = "1.2.3.4.5"
                    },
                    new XdsReferenceIdentifier
                    {
                         Id = "DC0001",
                         IdType = "urn:ihe:iti:xds:2013:uniqueId",
                         UniversalId = "6.6.6"
                    }
                },
                LimitedMetadata = true,
                DocumentEntryType = "urn:uuid:7edca82f-054d-47f2-a032-9b2a5b5186c1"

            };

            var package = document.ToRegistryObject();
            package.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Xdsb.DocumentEntry_Test01.xml")));
        }
    }
}
