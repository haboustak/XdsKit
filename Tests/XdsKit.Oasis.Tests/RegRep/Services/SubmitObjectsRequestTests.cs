using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests.RegRep.Services
{
    [TestFixture]
    public class SubmitObjectsRequestTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var request = Resource.Deserialize<SubmitObjectsRequest>("Resources.Services.SubmitObjectsRequest_Test01.xml");
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", request.Id);
            Assert.AreEqual("This is a comment", request.Comment);

            Assert.AreEqual(1, request.RegistryObjects.ExtrinsicObjects.Count);

            var document = request.RegistryObjects.ExtrinsicObjects[0];
            OasisAssert.ExtrinsicObject(document,
                "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b", "text/xml", "urn:xdskit:com:c7ptmx37tfbcwy8ky7c", false);
            Assert.AreEqual(4, document.Slots.Count);
            OasisAssert.Slot(document.Slots[0], "creationTime", "", new[] { "20051224" });
            OasisAssert.Slot(document.Slots[1], "languageCode", "", new[] { "en-us" });
            OasisAssert.Slot(document.Slots[2], "serviceStartTime", "", new[] { "200412230800" });
            OasisAssert.Slot(document.Slots[3], "serviceStopTime", "", new[] { "200412230801" });

            Assert.AreEqual(2, request.RegistryObjects.RegistryPackages.Count);
            var package = request.RegistryObjects.RegistryPackages[0];
            OasisAssert.RegistryPackage(package, "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d", "Progress Note", "Progress Note for 8/1/2015");
            Assert.AreEqual(1, package.Slots.Count);
            OasisAssert.Slot(package.Slots[0], "submissionTime", "", new[] { "20041225235050" });
            Assert.AreEqual(1, package.ExternalIdentifiers.Count);
            OasisAssert.ExternalIdentifier(package.ExternalIdentifiers[0], "urn:xdskit:com:c7ptmx37tfbcwy8ky7e", "urn:xdskit:com:c7ptmx37tfbcwy8ky7f", "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d", "T-77012382", "XDSSubmissionSet.patientId", "");

            package = request.RegistryObjects.RegistryPackages[1];
            OasisAssert.RegistryPackage(package, "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g", "Progress Notes", "");

            Assert.AreEqual(3, request.RegistryObjects.Associations.Count);
            OasisAssert.Association(request.RegistryObjects.Associations[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7h", AssociationType.HasMember, "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d", "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g");
            OasisAssert.Association(request.RegistryObjects.Associations[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7i", AssociationType.HasMember, "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g", "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b");
            OasisAssert.Association(request.RegistryObjects.Associations[2],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7j", AssociationType.HasMember, "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d", "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b");
        }
        
        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Services.SubmitObjectsRequest_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<SubmitObjectsRequest>();
            list.DeepEquals(list2);
        }

        private SubmitObjectsRequest Build_Test01()
        {
            var request = new SubmitObjectsRequest
            {
                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Comment = "This is a comment",
                RegistryObjects = new RegistryObjectList
                {
                    ExtrinsicObjects = new List<ExtrinsicObject>
                    {
                        new ExtrinsicObject
                        {
                            Id = "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b",
                            MimeType = "text/xml",
                            ObjectType = "urn:xdskit:com:c7ptmx37tfbcwy8ky7c",
                            Slots = new List<Slot>
                            {
                                new Slot
                                {
                                    Name = "creationTime",
                                    Values = new List<string> {"20051224"}
                                },
                                new Slot
                                {
                                    Name = "languageCode",
                                    Values = new List<string> {"en-us"}
                                },
                                new Slot
                                {
                                    Name = "serviceStartTime",
                                    Values = new List<string> {"200412230800"}
                                },
                                new Slot
                                {
                                    Name = "serviceStopTime",
                                    Values = new List<string> {"200412230801"}
                                }
                            }
                        }
                    },
                    RegistryPackages = new List<RegistryPackage>
                    {
                        new RegistryPackage
                        {
                            Id = "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d",
                            Name = XmlUtil.LocalString("Progress Note"),
                            Description = XmlUtil.LocalString("Progress Note for 8/1/2015"),
                            Slots = new List<Slot>
                            {
                                new Slot
                                {
                                    Name = "submissionTime",
                                    Values = new List<string> {"20041225235050"}
                                }
                            },
                            ExternalIdentifiers = new List<ExternalIdentifier>
                            {
                                new ExternalIdentifier
                                {
                                    Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7e",
                                    RegistryObject = "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d",
                                    IdentificationScheme = "urn:xdskit:com:c7ptmx37tfbcwy8ky7f",
                                    Value = "T-77012382",
                                    Name = XmlUtil.LocalString("XDSSubmissionSet.patientId")
                                }
                            }
                        },
                        new RegistryPackage
                        {
                            Id = "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g",
                            Name = XmlUtil.LocalString("Progress Notes")
                        }
                    },
                    Associations = new List<Association>
                    {
                        new Association
                        {
                            Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7h",
                            AssociationType = AssociationType.HasMember,
                            Source = "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d",
                            Target = "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g"
                        },
                        new Association
                        {
                            Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7i",
                            AssociationType = AssociationType.HasMember,
                            Source = "urn:xdskit:com:Folder:c7ptmx37tfbcwy8ky7g",
                            Target = "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b"
                        },
                        new Association
                        {
                            Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7j",
                            AssociationType = AssociationType.HasMember,
                            Source = "urn:xdskit:com:SubmissionSet:c7ptmx37tfbcwy8ky7d",
                            Target = "urn:xdskit:com:Document:c7ptmx37tfbcwy8ky7b",
                            Slots = new List<Slot>
                            {
                                new Slot
                                {
                                    Name = "SubmissionSetStatus",
                                    Values = new List<string> {"Original"}
                                }
                            }
                        }
                    }
                }
            };
            return request;
        }
    }
}
