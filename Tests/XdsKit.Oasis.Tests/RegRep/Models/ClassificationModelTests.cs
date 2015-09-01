using System.Runtime;
using System.Xml.Serialization;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.Resources
{
    [TestFixture]
    public class ClassificationModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.ClassificationModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

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
            AssertClassificationNode(scheme.Nodes[0],
                "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer", 
                "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer",
                "NoviceCustomer", "NoviceCustomer", "This is customer is an XdsKit beginner.");
            AssertClassificationNode(scheme.Nodes[1],
                "urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:CompetentCustomer",
                "CompetentCustomer", "CompetentCustomer", "This is customer is competent with XdsKit.");
            AssertClassificationNode(scheme.Nodes[2],
                "urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:ProficientCustomer",
                "ProficientCustomer", "ProficientCustomer", "This is customer is proficient in all things XdsKit.");
            AssertClassificationNode(scheme.Nodes[3],
                "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer",
                "ExpertCustomer", "ExpertCustomer", "This is customer is an XdsKit expert.");
            AssertClassificationNode(scheme.Nodes[4],
                "urn:xdskit:com:classificationScheme:CustomerType:Partner",
                "urn:xdskit:com:classificationScheme:CustomerType:Partner",
                "Partner", "Partner", "This is customer is one of our XdsKit partners.");


            Assert.AreEqual(4, list.Classifications.Count);
            AssertClassification(list.Classifications[0],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "urn:xdskit:com:classificationScheme:CustomerType:NoviceCustomer", null);
            AssertClassification(list.Classifications[1],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", "urn:xdskit:com:classificationScheme:CustomerType:Partner", null);
            AssertClassification(list.Classifications[2],
                "urn:xdskit:com:classificationScheme:CustomerType", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "urn:xdskit:com:classificationScheme:CustomerType:ExpertCustomer", null);
            AssertClassification(list.Classifications[3],
                "urn:xdskit:com:classificationScheme:PartnerRegion", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", null, "Northeast");
        }

        private void AssertClassificationNode(ClassificationNode node, string id, string localId, string code,
            string name, string description)
        {

            Assert.AreEqual(id, node.Id);
            Assert.AreEqual(localId, node.LocalId);
            Assert.AreEqual(code, node.Code);
            Assert.AreEqual(name, node.Name.GetValue());
            Assert.AreEqual(name, node.Name.GetValue("en-US"));
            Assert.AreEqual(description, node.Description.GetValue());
            Assert.AreEqual(description, node.Description.GetValue("en-US"));
        }

        private void AssertClassification(Classification classification, string scheme, string objectId, string nodeId, string nodeRepresentation)
        {
            Assert.AreEqual(scheme ?? "", classification.ClassificationScheme ?? "");
            Assert.AreEqual(objectId ?? "", classification.ClassifiedObject ?? "");
            Assert.AreEqual(nodeId ?? "", classification.ClassificationNode ?? "");
            Assert.AreEqual(nodeRepresentation ?? "", classification.NodeRepresentation ?? "");
        }
    }
}
