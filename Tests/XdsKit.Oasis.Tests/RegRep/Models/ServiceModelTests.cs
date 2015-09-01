using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class ServiceModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.ServiceModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });
            Assert.AreEqual(1, list.Services.Count);
            var service = list.Services[0];
            Assert.AreEqual(1, service.ServiceBindings.Count);
            var binding = service.ServiceBindings[0];
            AssertBinding(binding, "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                "Find Resource Service binding (prod environment)", "Production environment binding for the Catalog's Find Resource service", 
                "https://services.xdskit.com/catalog/findResource", "urn:xdskit:com:CatalogService:findResource");

            AssertSpecificationLink(binding.SpecificationLinks[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7p", "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                "urn:xdskit:com:Documentation:CatalogService:findResource",
                "The find resources service has 2 parameters: ResourceType and Id",
                new[]
                {
                    "ResourceType. DataType: referenceUri. The type of resource within the Catalog",
                    "Id. DataType: anyUri. The ID of the resource to locate."
                });

            Assert.AreEqual(1, list.ServiceBindings.Count);
            binding = list.ServiceBindings[0];
            AssertBinding(binding, "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                "Find Resource Service binding (test environment)", "Test environment binding for the Catalog's Find Resource service",
                "https://test-services.xdskit.com/catalog/findResource", "urn:xdskit:com:CatalogService:findResource");

            AssertSpecificationLink(binding.SpecificationLinks[0],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7n", "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                "urn:xdskit:com:Documentation:CatalogService:findResource",
                "The find resources service has 2 parameters: ResourceType and Id",
                new[]
                {
                    "ResourceType. DataType: referenceUri. The type of resource within the Catalog",
                    "Id. DataType: anyUri. The ID of the resource to locate."
                });
        }

        private void AssertBinding(ServiceBinding binding, string id, string name, string description, string uri, string serviceId)
        {
            Assert.AreEqual(id ?? "", binding.Id ?? "");
            Assert.AreEqual(name ?? "", binding.Name.GetValue() ?? "");
            Assert.AreEqual(name ?? "", binding.Name.GetValue("en-US") ?? "");
            Assert.AreEqual(description ?? "", binding.Description.GetValue() ?? "");
            Assert.AreEqual(description ?? "", binding.Description.GetValue("en-US") ?? "");
            Assert.AreEqual(uri, binding.AccessURI ?? "");
            Assert.AreEqual(serviceId, binding.Service ?? "");
        }

        private void AssertSpecificationLink(SpecificationLink link, 
            string id, string binding, string specificationObject, string usageDescription, IList<string> parameters)
        {
            Assert.AreEqual(id ?? "", link.Id ?? "");
            Assert.AreEqual(binding ?? "", link.ServiceBinding ?? "");
            Assert.AreEqual(specificationObject ?? "", link.SpecificationObject ?? "");
            Assert.AreEqual(usageDescription ?? "", link.UsageDescription.GetValue() ?? "");
            Assert.AreEqual(usageDescription ?? "", link.UsageDescription.GetValue("en-US") ?? "");
            for (var i = 0; i < parameters.Count(); i++)
                Assert.AreEqual(parameters[i], link.UsageParameters[i]);
        }
    }
}
