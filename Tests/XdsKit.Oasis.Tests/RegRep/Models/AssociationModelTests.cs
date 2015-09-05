using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;


namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class AssociationModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.AssociationModel_Test01.xml");
            Assert.AreEqual(1, list.RegistryPackages.Count);
            Assert.AreEqual(2, list.ExtrinsicObjects.Count);
            Assert.AreEqual(2, list.Associations.Count);
            OasisAssert.Association(list.Associations[0], "", AssociationType.HasMember, "urn:xdskit:com:c7ptmx37tfbcwy8ky7m", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n");
            OasisAssert.Association(list.Associations[1], "", AssociationType.HasMember, "urn:xdskit:com:c7ptmx37tfbcwy8ky7m", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p");
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.AssociationModel_Test01.xml")));
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
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        ObjectType = "urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage"
                    }
                },
                ExtrinsicObjects = new List<ExtrinsicObject>
                {
                    new ExtrinsicObject
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                        MimeType = "text/plain",
                        ObjectType = "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                        IsOpaque = true,
                        VersionInfo = new VersionInfo
                        {
                            VersionName = "1.0+revision.5",
                            Comment = "This is the latest version"
                        }
                    },
                    new ExtrinsicObject
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                        MimeType = "application/pdf",
                        ObjectType = "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                        IsOpaque = false,
                        VersionInfo = new VersionInfo {VersionName = "775"}
                    }
                },
                Associations = new List<Association>
                {
                    new Association
                    {
                        AssociationType = AssociationType.HasMember,
                        Source = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        Target = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                    },
                    new Association
                    {
                        AssociationType = AssociationType.HasMember,
                        Source = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        Target = "urn:xdskit:com:c7ptmx37tfbcwy8ky7p"
                    }
                }
            };

            return list;
        }

    }
}
