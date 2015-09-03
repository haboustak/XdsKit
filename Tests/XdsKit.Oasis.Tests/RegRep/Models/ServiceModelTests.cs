using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            var list = Resource.Deserialize<RegistryObjectList>("Resources.ServiceModel_Test01.xml");
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

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.ServiceModel_Test01.xml")));
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
                Services = new List<Service>
                {
                    new Service
                    {
                        Id = "urn:xdskit:com:CatalogService:findResource",
                        LocalId = "urn:xdskit:com:CatalogService:findResource",
                        Name = XmlUtil.LocalString("Find Resource Service"),
                        Description = XmlUtil.LocalString("This services searches the global catalog for resources."),
                        ServiceBindings = new List<ServiceBinding>
                        {
                            new ServiceBinding
                            {
                                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                                AccessURI = "https://services.xdskit.com/catalog/findResource",
                                Service = "urn:xdskit:com:CatalogService:findResource",
                                Name = XmlUtil.LocalString("Find Resource Service binding (prod environment)"),
                                Description =
                                    XmlUtil.LocalString(
                                        "Production environment binding for the Catalog's Find Resource service"),
                                SpecificationLinks = new List<SpecificationLink>
                                {
                                    new SpecificationLink
                                    {
                                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7p",
                                        ServiceBinding = "urn:xdskit:com:c7ptmx37tfbcwy8ky7o",
                                        SpecificationObject = "urn:xdskit:com:Documentation:CatalogService:findResource",
                                        UsageDescription =
                                            XmlUtil.LocalString(
                                                "The find resources service has 2 parameters: ResourceType and Id"),
                                        UsageParameters = new List<string>
                                        {
                                            "ResourceType. DataType: referenceUri. The type of resource within the Catalog",
                                            "Id. DataType: anyUri. The ID of the resource to locate."
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                ServiceBindings = new List<ServiceBinding>
                {
                    new ServiceBinding
                    {
                        Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        AccessURI = "https://test-services.xdskit.com/catalog/findResource",
                        Service = "urn:xdskit:com:CatalogService:findResource",
                        Name = XmlUtil.LocalString("Find Resource Service binding (test environment)"),
                        Description =
                            XmlUtil.LocalString(
                                "Test environment binding for the Catalog's Find Resource service"),
                        SpecificationLinks = new List<SpecificationLink>
                        {
                            new SpecificationLink
                            {
                                Id = "urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                                ServiceBinding = "urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                                SpecificationObject = "urn:xdskit:com:Documentation:CatalogService:findResource",
                                UsageDescription =
                                    XmlUtil.LocalString(
                                        "The find resources service has 2 parameters: ResourceType and Id"),
                                UsageParameters = new List<string>
                                {
                                    "ResourceType. DataType: referenceUri. The type of resource within the Catalog",
                                    "Id. DataType: anyUri. The ID of the resource to locate."
                                }
                            }
                        }
                    }
                }
            };

            return list;
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
