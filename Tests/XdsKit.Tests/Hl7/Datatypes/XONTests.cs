using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class XONTests
    {
        public string All = "XON.OrganizationName^XON.OrganizationNameTypeCode^17023^3^XON.CheckDigitScheme^XON.AssigningAuthority.NamespaceId&XON.AssigningAuthority.UniversalId&XON.AssigningAuthority.UniversalIdType^XON.IdentifierTypeCode^XON.AssigningFacility.NamespaceId&XON.AssigningFacility.UniversalId&XON.AssigningFacility.UniversalIdType^XON.NameRepresentationCode^XON.OrganizationIdentifier";
        public string First = "XON.OrganizationName";
        public string Last = "^^^^^^^^^XON.OrganizationIdentifier";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new XON
            {
                OrganizationName = new ST { Value = "XON.OrganizationName" },
                OrganizationNameTypeCode = new IS { Value = "XON.OrganizationNameTypeCode" },
                IdNumber = new NM { Value = 17023m },
                CheckDigit = new NM { Value = 3m },
                CheckDigitScheme = new ID { Value = "XON.CheckDigitScheme" },
                AssigningAuthority = new HD
                {
                    NamespaceId = new IS { Value = "XON.AssigningAuthority.NamespaceId" },
                    UniversalId = new ST { Value = "XON.AssigningAuthority.UniversalId" },
                    UniversalIdType = new ID { Value = "XON.AssigningAuthority.UniversalIdType" }
                },
                IdentifierTypeCode = new ID { Value = "XON.IdentifierTypeCode" },
                AssigningFacility = new HD
                {
                    NamespaceId = new IS { Value = "XON.AssigningFacility.NamespaceId" },
                    UniversalId = new ST { Value = "XON.AssigningFacility.UniversalId" },
                    UniversalIdType = new ID { Value = "XON.AssigningFacility.UniversalIdType" }
                },
                NameRepresentationCode = new ID { Value = "XON.NameRepresentationCode" },
                OrganizationIdentifier = new ST { Value = "XON.OrganizationIdentifier" }
            };
            Assert.AreEqual(All, field.Encode());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new XON
            {
                OrganizationName = new ST { Value = "XON.OrganizationName" }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new XON
            {
                OrganizationIdentifier = new ST { Value = "XON.OrganizationIdentifier" }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new XON(), All);
            Assert.AreEqual("XON.OrganizationName", field.OrganizationName.Value);
            Assert.AreEqual("XON.OrganizationNameTypeCode", field.OrganizationNameTypeCode.Value);
            Assert.AreEqual(17023m, field.IdNumber.Value);
            Assert.AreEqual(3m, field.CheckDigit.Value);
            Assert.AreEqual("XON.CheckDigitScheme", field.CheckDigitScheme.Value);
            Assert.AreEqual("XON.AssigningAuthority.NamespaceId", field.AssigningAuthority.NamespaceId.Value);
            Assert.AreEqual("XON.AssigningAuthority.UniversalId", field.AssigningAuthority.UniversalId.Value);
            Assert.AreEqual("XON.AssigningAuthority.UniversalIdType", field.AssigningAuthority.UniversalIdType.Value);
            Assert.AreEqual("XON.IdentifierTypeCode", field.IdentifierTypeCode.Value);
            Assert.AreEqual("XON.AssigningFacility.NamespaceId", field.AssigningFacility.NamespaceId.Value);
            Assert.AreEqual("XON.AssigningFacility.UniversalId", field.AssigningFacility.UniversalId.Value);
            Assert.AreEqual("XON.AssigningFacility.UniversalIdType", field.AssigningFacility.UniversalIdType.Value);
            Assert.AreEqual("XON.NameRepresentationCode", field.NameRepresentationCode.Value);
            Assert.AreEqual("XON.OrganizationIdentifier", field.OrganizationIdentifier.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new XON(), First);
            Assert.AreEqual("XON.OrganizationName", field.OrganizationName.Value);
            Assert.IsNull(field.OrganizationNameTypeCode);
            Assert.IsNull(field.IdNumber);
            Assert.IsNull(field.CheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.NameRepresentationCode);
            Assert.IsNull(field.OrganizationIdentifier);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new XON(), Last);
            Assert.IsNull(field.OrganizationName);
            Assert.IsNull(field.OrganizationNameTypeCode);
            Assert.IsNull(field.IdNumber);
            Assert.IsNull(field.CheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.NameRepresentationCode);
            Assert.AreEqual("XON.OrganizationIdentifier", field.OrganizationIdentifier.Value);
        }
    }
}
