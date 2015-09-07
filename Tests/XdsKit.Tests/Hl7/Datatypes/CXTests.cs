using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class CXTests
    {
        public string All = "CX.IdNumber^CX.CheckDigit^CX.CheckDigitScheme^CX.AssigningAuthority.NamespaceId&CX.AssigningAuthority.UniversalId&CX.AssigningAuthority.UniversalIdType^CX.IdentifierTypeCode^CX.AssigningFacility.NamespaceId&CX.AssigningFacility.UniversalId&CX.AssigningFacility.UniversalIdType^20140101^20151231^CX.AssigningJurisdiction.Identifier&CX.AssigningJurisdiction.Text&CX.AssigningJurisdiction.NameofCodingSystem&CX.AssigningJurisdiction.AlternateIdentifier&CX.AssigningJurisdiction.AlternateText&CX.AssigningJurisdiction.NameofAlternateCodingSystem&CX.AssigningJurisdiction.CodingSystemVersionId&CX.AssigningJurisdiction.AlternateCodingSystemVersionId&CX.AssigningJurisdiction.OriginalText^CX.AssigningAgencyOrDepartment.Identifier&CX.AssigningAgencyOrDepartment.Text&CX.AssigningAgencyOrDepartment.NameofCodingSystem&CX.AssigningAgencyOrDepartment.AlternateIdentifier&CX.AssigningAgencyOrDepartment.AlternateText&CX.AssigningAgencyOrDepartment.NameofAlternateCodingSystem&CX.AssigningAgencyOrDepartment.CodingSystemVersionId&CX.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId&CX.AssigningAgencyOrDepartment.OriginalText";
        public string First = "CX.IdNumber";
        public string Last = "^^^^^^^^^&&&&&&&&CX.AssigningAgencyOrDepartment.OriginalText";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new CX
            {
                IdNumber = new ST { Value = "CX.IdNumber" },
                CheckDigit = new ST { Value = "CX.CheckDigit" },
                CheckDigitScheme = new ID { Value = "CX.CheckDigitScheme" },
                AssigningAuthority = new HD
                {
                    NamespaceId = new IS { Value = "CX.AssigningAuthority.NamespaceId" },
                    UniversalId = new ST { Value = "CX.AssigningAuthority.UniversalId" },
                    UniversalIdType = new ID { Value = "CX.AssigningAuthority.UniversalIdType" }
                },
                IdentifierTypeCode = new ID { Value = "CX.IdentifierTypeCode" },
                AssigningFacility = new HD
                {
                    NamespaceId = new IS { Value = "CX.AssigningFacility.NamespaceId" },
                    UniversalId = new ST { Value = "CX.AssigningFacility.UniversalId" },
                    UniversalIdType = new ID { Value = "CX.AssigningFacility.UniversalIdType" }
                },
                EffectiveDate = new DT(2014,1,1),
                ExpirationDate = new DT(2015,12,31),
                AssigningJurisdiction = new CWE
                {
                    Identifier = new ST { Value = "CX.AssigningJurisdiction.Identifier" },
                    Text = new ST { Value = "CX.AssigningJurisdiction.Text" },
                    NameofCodingSystem = new ID { Value = "CX.AssigningJurisdiction.NameofCodingSystem" },
                    AlternateIdentifier = new ST { Value = "CX.AssigningJurisdiction.AlternateIdentifier" },
                    AlternateText = new ST { Value = "CX.AssigningJurisdiction.AlternateText" },
                    NameofAlternateCodingSystem = new ID { Value = "CX.AssigningJurisdiction.NameofAlternateCodingSystem" },
                    CodingSystemVersionId = new ST { Value = "CX.AssigningJurisdiction.CodingSystemVersionId" },
                    AlternateCodingSystemVersionId = new ST { Value = "CX.AssigningJurisdiction.AlternateCodingSystemVersionId" },
                    OriginalText = new ST { Value = "CX.AssigningJurisdiction.OriginalText" }
                },
                AssigningAgencyOrDepartment = new CWE
                {
                    Identifier = new ST { Value = "CX.AssigningAgencyOrDepartment.Identifier" },
                    Text = new ST { Value = "CX.AssigningAgencyOrDepartment.Text" },
                    NameofCodingSystem = new ID { Value = "CX.AssigningAgencyOrDepartment.NameofCodingSystem" },
                    AlternateIdentifier = new ST { Value = "CX.AssigningAgencyOrDepartment.AlternateIdentifier" },
                    AlternateText = new ST { Value = "CX.AssigningAgencyOrDepartment.AlternateText" },
                    NameofAlternateCodingSystem = new ID { Value = "CX.AssigningAgencyOrDepartment.NameofAlternateCodingSystem" },
                    CodingSystemVersionId = new ST { Value = "CX.AssigningAgencyOrDepartment.CodingSystemVersionId" },
                    AlternateCodingSystemVersionId = new ST { Value = "CX.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId" },
                    OriginalText = new ST { Value = "CX.AssigningAgencyOrDepartment.OriginalText" }
                }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new CX
            {
                IdNumber = new ST { Value = "CX.IdNumber" }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new CX
            {
                AssigningAgencyOrDepartment = new CWE
                {
                    OriginalText = new ST { Value = "CX.AssigningAgencyOrDepartment.OriginalText" }
                }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new CX(), All);
            Assert.AreEqual("CX.IdNumber", field.IdNumber.Value);
            Assert.AreEqual("CX.CheckDigit", field.CheckDigit.Value);
            Assert.AreEqual("CX.CheckDigitScheme", field.CheckDigitScheme.Value);
            Assert.AreEqual("CX.AssigningAuthority.NamespaceId", field.AssigningAuthority.NamespaceId.Value);
            Assert.AreEqual("CX.AssigningAuthority.UniversalId", field.AssigningAuthority.UniversalId.Value);
            Assert.AreEqual("CX.AssigningAuthority.UniversalIdType", field.AssigningAuthority.UniversalIdType.Value);
            Assert.AreEqual("CX.IdentifierTypeCode", field.IdentifierTypeCode.Value);
            Assert.AreEqual("CX.AssigningFacility.NamespaceId", field.AssigningFacility.NamespaceId.Value);
            Assert.AreEqual("CX.AssigningFacility.UniversalId", field.AssigningFacility.UniversalId.Value);
            Assert.AreEqual("CX.AssigningFacility.UniversalIdType", field.AssigningFacility.UniversalIdType.Value);
            Assert.AreEqual("CX.AssigningFacility.NamespaceId", field.AssigningFacility.NamespaceId.Value);
            Assert.AreEqual("20140101", field.EffectiveDate.Value);
            Assert.AreEqual("20151231", field.ExpirationDate.Value);
            
            Assert.AreEqual("CX.AssigningJurisdiction.Identifier", field.AssigningJurisdiction.Identifier.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.Text", field.AssigningJurisdiction.Text.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.NameofCodingSystem", field.AssigningJurisdiction.NameofCodingSystem.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.AlternateIdentifier", field.AssigningJurisdiction.AlternateIdentifier.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.AlternateText", field.AssigningJurisdiction.AlternateText.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.NameofAlternateCodingSystem", field.AssigningJurisdiction.NameofAlternateCodingSystem.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.CodingSystemVersionId", field.AssigningJurisdiction.CodingSystemVersionId.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.AlternateCodingSystemVersionId", field.AssigningJurisdiction.AlternateCodingSystemVersionId.Value);
            Assert.AreEqual("CX.AssigningJurisdiction.OriginalText", field.AssigningJurisdiction.OriginalText.Value);

            Assert.AreEqual("CX.AssigningAgencyOrDepartment.Identifier", field.AssigningAgencyOrDepartment.Identifier.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.Text", field.AssigningAgencyOrDepartment.Text.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.NameofCodingSystem", field.AssigningAgencyOrDepartment.NameofCodingSystem.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.AlternateIdentifier", field.AssigningAgencyOrDepartment.AlternateIdentifier.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.AlternateText", field.AssigningAgencyOrDepartment.AlternateText.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.NameofAlternateCodingSystem", field.AssigningAgencyOrDepartment.NameofAlternateCodingSystem.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.CodingSystemVersionId", field.AssigningAgencyOrDepartment.CodingSystemVersionId.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId", field.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId.Value);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.OriginalText", field.AssigningAgencyOrDepartment.OriginalText.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new CX(), First);
            Assert.AreEqual("CX.IdNumber", field.IdNumber.Value);
            Assert.IsNull(field.CheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.EffectiveDate);
            Assert.IsNull(field.ExpirationDate);
            Assert.IsNull(field.AssigningJurisdiction);
            Assert.IsNull(field.AssigningAgencyOrDepartment);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new CX(), Last);
            Assert.IsNull(field.IdNumber);
            Assert.IsNull(field.CheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.EffectiveDate);
            Assert.IsNull(field.ExpirationDate);
            Assert.IsNull(field.AssigningJurisdiction);
            Assert.AreEqual("CX.AssigningAgencyOrDepartment.OriginalText", field.AssigningAgencyOrDepartment.OriginalText.Value);
        }

    }
}
