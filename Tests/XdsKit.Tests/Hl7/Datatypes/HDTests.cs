using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class HDTests
    {
        public string All = "HD.NamespaceId^HD.UniversalId^HD.UniversalIdType";
        public string First = "HD.NamespaceId";
        public string Last = "^^HD.UniversalIdType";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new HD
            {
                NamespaceId = new IS { Value = "HD.NamespaceId" },
                UniversalId = new ST { Value = "HD.UniversalId" },
                UniversalIdType = new ID { Value = "HD.UniversalIdType" }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new HD
            {
                NamespaceId = new IS { Value = "HD.NamespaceId" }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new HD
            {
                UniversalIdType = new ID { Value = "HD.UniversalIdType" }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new HD(), All);
            Assert.AreEqual("HD.NamespaceId", field.NamespaceId.Value);
            Assert.AreEqual("HD.UniversalId", field.UniversalId.Value);
            Assert.AreEqual("HD.UniversalIdType", field.UniversalIdType.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new HD(), First);
            Assert.AreEqual("HD.NamespaceId", field.NamespaceId.Value);
            Assert.IsNull(field.UniversalId);
            Assert.IsNull(field.UniversalIdType);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new HD(), Last);
            Assert.IsNull(field.NamespaceId);
            Assert.IsNull(field.UniversalId);
            Assert.AreEqual("HD.UniversalIdType", field.UniversalIdType.Value);
        }
    }
}
