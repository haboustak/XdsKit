using System.Xml;
using System.Xml.Serialization;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class RegistryObjectListTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.RegistryObjects_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });
        }

        [Test]
        public void Should_Deserialize_Test02()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.RegistryObjects_Test02.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });
        }
    }
}
