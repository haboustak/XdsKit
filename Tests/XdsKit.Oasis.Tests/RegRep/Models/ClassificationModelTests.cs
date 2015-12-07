using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.Resources
{
    [TestFixture]
    public class ClassificationModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.ClassificationModel_Test01.xml");

            Assert.AreEqual(1, list.ClassificationSchemes.Count);
            var scheme = list.ClassificationSchemes[0];
            Assert.AreEqual("urn:xdskit:com:classificationScheme:CustomerType", scheme.Id);
            Assert.AreEqual("urn:xdskit:com:classificationScheme:CustomerType", scheme.LocalId);
            Assert.AreEqual(true, scheme.IsInternal);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:NodeType:UniqueCode", scheme.NodeType);
            Assert.AreEqual("CustomerType", scheme.Name.GetValue());
            Assert.AreEqual("CustomerType", scheme.Name.GetValue("en-US"));
            Assert.AreEqual("This is the ClassificationScheme for XdsKit customer types", scheme.Description.GetValue());
            Assert.AreEqual("This is the ClassificationScheme for XdsKit customer types", scheme.Description.GetValue("en-US"));
            Assert.AreEqual(5, scheme.Nodes.Count);
            OasisAssert.ClassificationNode(scheme.Nodes[0],
                "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer", 
                "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer",
                "NoviceCustomer", "NoviceCustomer", "This is customer is an XdsKit beginner.");
            OasisAssert.ClassificationNode(scheme.Nodes[1],
                "urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                "CompetentCustomer", "CompetentCustomer", "This is customer is competent with XdsKit.");
            OasisAssert.ClassificationNode(scheme.Nodes[2],
                "urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                "ProficientCustomer", "ProficientCustomer", "This is customer is proficient in all things XdsKit.");
            OasisAssert.ClassificationNode(scheme.Nodes[3],
                "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                "ExpertCustomer", "ExpertCustomer", "This is customer is an XdsKit expert.");
            OasisAssert.ClassificationNode(scheme.Nodes[4],
                "urn:xdskit:com:classificationScheme:CustomerType:Partner",
                "urn:xdskit:com:classificationScheme:CustomerType:Partner",
                "Partner", "Partner", "This is customer is one of our XdsKit partners.");


            Assert.AreEqual(4, list.Classifications.Count);
            OasisAssert.Classification(list.Classifications[0],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer", null);
            OasisAssert.Classification(list.Classifications[1],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", "urn:xdskit:com:classificationScheme:CustomerType:Partner", null);
            OasisAssert.Classification(list.Classifications[2],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer", null);
            OasisAssert.Classification(list.Classifications[3],
                "urn:xdskit:com:classificationScheme:PartnerRegion", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", null, "Northeast");
        }
        
        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.ClassificationModel_Test01.xml")));
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
                ClassificationSchemes = new List<ClassificationScheme>
                {
                    new ClassificationScheme
                    {
                        LocalId = "urn:xdskit:com:classificationScheme:CustomerType",
                        Id = "urn:xdskit:com:classificationScheme:CustomerType",
                        IsInternal = true,
                        NodeType = "urn:oasis:names:tc:ebxml-regrep:NodeType:UniqueCode",
                        Name = XmlUtil.LocalString("CustomerType"),
                        Description = XmlUtil.LocalString(
                            "This is the ClassificationScheme for XdsKit customer types",
                            "UTF-16"),
                        Nodes = new List<ClassificationNode>
                        {
                            new ClassificationNode
                            {
                                LocalId="urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer",
                                Id="urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer",
                                Code="NoviceCustomer",
                                Name = XmlUtil.LocalString("NoviceCustomer", "ASCII"),
                                Description = XmlUtil.LocalString("This is customer is an XdsKit beginner.")
                            },
                            new ClassificationNode
                            {
                                LocalId="urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                                Id="urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                                Code="CompetentCustomer",
                                Name = XmlUtil.LocalString("CompetentCustomer"),
                                Description = XmlUtil.LocalString("This is customer is competent with XdsKit.")
                            },
                            new ClassificationNode
                            {
                                LocalId="urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                                Id="urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                                Code="ProficientCustomer",
                                Name = XmlUtil.LocalString("ProficientCustomer"),
                                Description = XmlUtil.LocalString("This is customer is proficient in all things XdsKit.")
                            },
                            new ClassificationNode
                            {
                                LocalId="urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                                Id="urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                                Code="ExpertCustomer",
                                Name = XmlUtil.LocalString("ExpertCustomer"),
                                Description = XmlUtil.LocalString("This is customer is an XdsKit expert.")
                            },
                            new ClassificationNode
                            {
                                LocalId="urn:xdskit:com:classificationScheme:CustomerType:Partner",
                                Id="urn:xdskit:com:classificationScheme:CustomerType:Partner",
                                Code="Partner",
                                Name = XmlUtil.LocalString("Partner"),
                                Description = XmlUtil.LocalString("This is customer is one of our XdsKit partners.")
                            }
                        }
                    }

                },
                Classifications = new List<Classification>
                {
                    new Classification
                    {
                        ClassificationScheme="urn:xdskit:com:classificationScheme:CustomerType",
                        ClassificationNode="urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer",
                        ClassifiedObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                    },
                    new Classification
                    {
                        ClassificationScheme="urn:xdskit:com:classificationScheme:CustomerType",
                        ClassificationNode="urn:xdskit:com:classificationScheme:CustomerType:Partner",
                        ClassifiedObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7o"
                    },
                    new Classification
                    {
                        ClassificationScheme="urn:xdskit:com:classificationScheme:CustomerType",
                        ClassificationNode="urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                        ClassifiedObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7p"
                    },
                    new Classification
                    {
                        ClassificationScheme="urn:xdskit:com:classificationScheme:PartnerRegion",
                        NodeRepresentation="Northeast",
                        ClassifiedObject="urn:xdskit:com:c7ptmx37tfbcwy8ky7o"
                    }
                },
                Organizations = new List<Organization>
                {
                    new Organization
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                        Home="https://services.xdskit.com/organizations",
                        PrimaryContact="urn:xdskit:com:c7ptmx37tfbcwy8ky7a"
                    },
                    new Organization
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                        Home="https://services.xdskit.com/organizations",
                        PrimaryContact="urn:xdskit:com:c7ptmx37tfbcwy8ky7b"
                    },
                    new Organization
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                        Home="https://services.xdskit.com/organizations",
                        PrimaryContact="urn:xdskit:com:c7ptmx37tfbcwy8ky7c"
                    }
                }
            };

            return list;
        }

    }
}
