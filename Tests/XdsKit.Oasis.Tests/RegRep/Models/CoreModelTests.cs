using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class CoreModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.CoreModel_Test01.xml");

            Assert.AreEqual(2, list.RegistryPackages.Count);

            var package = list.RegistryPackages[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", package.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage", package.ObjectType);
            Assert.AreEqual(2, package.RegistryObjects.ExtrinsicObjects.Count);
            OasisAssert.ExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "text/plain", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", true);
            OasisAssert.ExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "application/pdf", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", false);

            Assert.AreEqual(2, package.ExternalIdentifiers.Count);
            OasisAssert.ExternalIdentifier(
                package.ExternalIdentifiers[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7q", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "1", "", "");
            OasisAssert.ExternalIdentifier(
                package.ExternalIdentifiers[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7r", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "2", "", "");

            package = list.RegistryPackages[1];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7s", package.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage", package.ObjectType);
            Assert.AreEqual(1, package.RegistryObjects.ExtrinsicObjects.Count);
            OasisAssert.ExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7t", "text/xml", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", false);

            Assert.AreEqual(1, package.ExternalIdentifiers.Count);
            OasisAssert.ExternalIdentifier(
                package.ExternalIdentifiers[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7w", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7t", "3", "", "");

        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.CoreModel_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test01()
        {
            var list = new RegistryObjectList
            {
                RegistryPackages = new List<RegistryPackage>
                {
                    new RegistryPackage
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        ObjectType="urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage",
                        RegistryObjects = new RegistryObjectList
                        {
                            ExtrinsicObjects = new List<ExtrinsicObject>
                            {
                                new ExtrinsicObject
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                                    MimeType="text/plain",
                                    ObjectType="urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                                    IsOpaque=true,
                                    VersionInfo = new VersionInfo
                                    {
                                        VersionName="1.0+revision.5", 
                                        Comment="This is the latest version"
                                    }
                                },
                                new ExtrinsicObject
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                                    MimeType="application/pdf",
                                    ObjectType="urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                                    IsOpaque=false,
                                    VersionInfo = new VersionInfo
                                    {
                                        VersionName="775"
                                    }
                                }
                            }
                        },
                        ExternalIdentifiers = new List<ExternalIdentifier>
                        {
                            new ExternalIdentifier
                            {
                                Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7q",
                                IdentificationScheme="urn:xdskit:com:documents:localid",
                                RegistryObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                                Value="1"
                            },
                            new ExternalIdentifier
                            {
                                Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7r",
                                IdentificationScheme="urn:xdskit:com:documents:localid",
                                RegistryObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                                Value="2"
                            }
                        }
                    },
                    new RegistryPackage
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7s",
                        ObjectType="urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage",
                        RegistryObjects = new RegistryObjectList
                        {
                            ExtrinsicObjects = new List<ExtrinsicObject>
                            {
                                new ExtrinsicObject
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7t",
                                    MimeType="text/xml",
                                    ObjectType="urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                                    IsOpaque=false
                                }
                            },
                            ExternalLinks = new List<ExternalLink>
                            {
                                new ExternalLink
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7u",
                                    ExternalUri="https://xdskit.com/links/c7ptmx37tfbcwy8ky7u"
                                },
                                new ExternalLink
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7v",
                                    ExternalUri="https://xdskit.com/links/c7ptmx37tfbcwy8ky7v"
                                }
                            }
                        },
                        ExternalIdentifiers = new List<ExternalIdentifier>
                        {
                            new ExternalIdentifier
                            {
                                Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7w",
                                IdentificationScheme="urn:xdskit:com:documents:localid",
                                RegistryObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7t",
                                Value="3"
                            }
                        }
                    }
                }
            };

            return list;
        }
    }
}
