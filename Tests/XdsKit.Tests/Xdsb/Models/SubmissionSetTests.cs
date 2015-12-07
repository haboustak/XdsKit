
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Xdsb.Models;

namespace XdsKit.Tests.Xdsb.Models
{
    [TestFixture]
    public class SubmissionSetTests
    {
        [Test]
        public void Should_Build_Submission_Test01()
        {
            var submission = new SubmissionSet
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
                Comments = "This is a new submission",
                ContentType = new ContentTypeCode
                {
                    Value = "application/pdf",
                    DisplayName = "Pdf"
                },
                EntryUuid = "Submission01",
                HomeCommunityId = "urn:oid:1.1.1.1.1.2",
                IntendedRecipients = new List<IntendedRecipient>
                {
                    new IntendedRecipient
                    {
                        Person = new XdsPerson
                        {
                            GivenName = "Specialist",
                            OwnSurname = "XdsKit",
                            Prefix = "Dr",
                            Degree = "MD"
                        },
                        Organization = new XdsOrganization
                        {
                            Name = "XdsKit Hospital",
                            OrganizationId = "1234567893",
                            UniversalId = "2.16.840.1.113883.4.6"
                        }
                    },
                    new IntendedRecipient
                    {
                        Person = new XdsPerson
                        {
                            GivenName = "Cariologist",
                            OwnSurname = "XdsKit",
                            Prefix = "Dr",
                            Degree = "MD"
                        },
                        Organization = new XdsOrganization
                        {
                            Name = "XdsKit Cardiology Care",
                            OrganizationId = "1234567893",
                            UniversalId = "2.16.840.1.113883.4.6"
                        }
                    },
                },
                PatientId = new XdsIdentifier
                {
                    Id = "XYZPAT01",
                    UniversalId = "9.0.1.2.3"
                },
                SourceId = "3.4.2.2.2",
                SubmissionTime = new DateTimeOffset(2015, 12, 4, 4, 21, 0, TimeSpan.Zero),
                Title = "SubmissionSet Title",
                UniqueId = "5.5.5.5.5"
            };

            var package = submission.ToRegistryObject();
            package.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Xdsb.SubmissionSet_Test01.xml")));
        }
    }
}
