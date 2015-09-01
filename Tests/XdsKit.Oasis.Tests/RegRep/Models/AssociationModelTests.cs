using System.Xml.Serialization;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;


namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class AssociationModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.AssociationModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });
            Assert.AreEqual(1, list.RegistryPackages.Count);
            Assert.AreEqual(2, list.ExtrinsicObjects.Count);
            Assert.AreEqual(2, list.Associations.Count);
            AssertAssociation(list.Associations[0],
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:HasMember", "urn:xdskit:com:c7ptmx37tfbcwy8ky7m", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n");
            AssertAssociation(list.Associations[1],
                "urn:oasis:names:tc:ebxml-regrep:AssociationType:HasMember", "urn:xdskit:com:c7ptmx37tfbcwy8ky7m", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p");
        }

        private void AssertAssociation(Association association, string type, string source, string target)
        {
            Assert.AreEqual(type, association.Type);
            Assert.AreEqual(source, association.Source);
            Assert.AreEqual(target, association.Target);
        }
    }
}
