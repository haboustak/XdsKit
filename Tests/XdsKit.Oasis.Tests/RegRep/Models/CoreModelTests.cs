
using NUnit.Framework;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class CoreModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.CoreModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

            Assert.AreEqual(2, list.RegistryPackages.Count);

            var package = list.RegistryPackages[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", package.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage", package.ObjectType);
            Assert.AreEqual(2, package.RegistryObjects.ExtrinsicObjects.Count);
            AssertExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "text/plain", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", true);
            AssertExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "application/pdf", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", false);

            Assert.AreEqual(2, package.ExternalIdentifiers.Count);
            AssertExternalIdentifier(
                package.ExternalIdentifiers[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7q", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "1");
            AssertExternalIdentifier(
                package.ExternalIdentifiers[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7r", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "2");

            package = list.RegistryPackages[1];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7s", package.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:RegistryPackage", package.ObjectType);
            Assert.AreEqual(1, package.RegistryObjects.ExtrinsicObjects.Count);
            AssertExtrinsicObject(
                package.RegistryObjects.ExtrinsicObjects[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7t", "text/xml", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o", false);

            Assert.AreEqual(1, package.ExternalIdentifiers.Count);
            AssertExternalIdentifier(
                package.ExternalIdentifiers[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7w", "urn:xdskit:com:documents:localid", "urn:xdskit:com:c7ptmx37tfbcwy8ky7t", "3");

        }

        private void AssertExtrinsicObject(ExtrinsicObject item,
            string id, string mimeType, string objectType, bool isOpaque)
        {
            Assert.AreEqual(id??"", item.Id??"");
            Assert.AreEqual(mimeType ?? "", item.MimeType ?? "");
            Assert.AreEqual(objectType ?? "", item.ObjectType ?? "");
            Assert.AreEqual(isOpaque, item.IsOpaque);
        }

        private void AssertExternalIdentifier(ExternalIdentifier item,
            string id, string identificationScheme, string registryObject, string value)
        {
            Assert.AreEqual(id ?? "", item.Id ?? "");
            Assert.AreEqual(identificationScheme ?? "", item.IdentificationScheme ?? "");
            Assert.AreEqual(registryObject ?? "", item.RegistryObject ?? "");
            Assert.AreEqual(value??"", item.Value??"");
        }

    }
}
