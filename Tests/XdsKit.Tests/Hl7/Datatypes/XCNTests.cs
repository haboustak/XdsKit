using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class XCNTests
    {
        public string All = "XCN.IdNumber^XCN.FamilyName.Surname&XCN.FamilyName.OwnSurnamePrefix&XCN.FamilyName.OwnSurname&XCN.FamilyName.SurnamePrefixFromPartnerSpouse&XCN.FamilyName.SurnameFromPartnerSpouse^XCN.GivenName^XCN.SecondandFurtherGivenNames^XCN.Suffix^XCN.Prefix^XCN.Degree^XCN.SourceTable^XCN.AssigningAuthority.NamespaceId&XCN.AssigningAuthority.UniversalId&XCN.AssigningAuthority.UniversalIdType^XCN.NameTypeCode^XCN.IdentifierCheckDigit^XCN.CheckDigitScheme^XCN.IdentifierTypeCode^XCN.AssigningFacility.NamespaceId&XCN.AssigningFacility.UniversalId&XCN.AssigningFacility.UniversalIdType^XCN.NameRepresentationCode^XCN.NameContext.Identifier&XCN.NameContext.Text&XCN.NameContext.NameofCodingSystem&XCN.NameContext.AlternateIdentifier1&XCN.NameContext.AlternateText1&XCN.NameContext.NameofAlternateCodingSystem1&XCN.NameContext.AlternateIdentifier2&XCN.NameContext.AlternateText2&XCN.NameContext.NameofAlternateCodingSystem2^20150906094212&20150907235959.9999-0400^XCN.NameAssemblyOrder^20150906094212&XCN.EffectiveDate.DegreeOfPrecision^20150906094212&XCN.ExpirationDate.DegreeOfPrecision^XCN.ProfessionalSuffix^XCN.AssigningJurisdiction.Identifier&XCN.AssigningJurisdiction.Text&XCN.AssigningJurisdiction.NameofCodingSystem&XCN.AssigningJurisdiction.AlternateIdentifier&XCN.AssigningJurisdiction.AlternateText&XCN.AssigningJurisdiction.NameofAlternateCodingSystem&XCN.AssigningJurisdiction.CodingSystemVersionId&XCN.AssigningJurisdiction.AlternateCodingSystemVersionId&XCN.AssigningJurisdiction.OriginalText^XCN.AssigningAgencyOrDepartment.Identifier&XCN.AssigningAgencyOrDepartment.Text&XCN.AssigningAgencyOrDepartment.NameofCodingSystem&XCN.AssigningAgencyOrDepartment.AlternateIdentifier&XCN.AssigningAgencyOrDepartment.AlternateText&XCN.AssigningAgencyOrDepartment.NameofAlternateCodingSystem&XCN.AssigningAgencyOrDepartment.CodingSystemVersionId&XCN.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId&XCN.AssigningAgencyOrDepartment.OriginalText";
        public string First = "XCN.IdNumber";
        public string Last = "^^^^^^^^^^^^^^^^^^^^^^&&&&&&&&XCN.AssigningAgencyOrDepartment.OriginalText";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new XCN
            {
                IdNumber = new ST { Value = "XCN.IdNumber" },
                FamilyName = new FN
                {
                    Surname = new ST { Value = "XCN.FamilyName.Surname" },
                    OwnSurnamePrefix = new ST { Value = "XCN.FamilyName.OwnSurnamePrefix" },
                    OwnSurname = new ST { Value = "XCN.FamilyName.OwnSurname" },
                    SurnamePrefixFromPartnerSpouse = new ST { Value = "XCN.FamilyName.SurnamePrefixFromPartnerSpouse" },
                    SurnameFromPartnerSpouse = new ST { Value = "XCN.FamilyName.SurnameFromPartnerSpouse" }
                },
                GivenName = new ST { Value = "XCN.GivenName" },
                SecondandFurtherGivenNames = new ST { Value = "XCN.SecondandFurtherGivenNames" },
                Suffix = new ST { Value = "XCN.Suffix" },
                Prefix = new ST { Value = "XCN.Prefix" },
                Degree = new IS { Value = "XCN.Degree" },
                SourceTable = new IS { Value = "XCN.SourceTable" },
                AssigningAuthority = new HD
                {
                    NamespaceId = new IS { Value = "XCN.AssigningAuthority.NamespaceId" },
                    UniversalId = new ST { Value = "XCN.AssigningAuthority.UniversalId" },
                    UniversalIdType = new ID { Value = "XCN.AssigningAuthority.UniversalIdType" }
                },
                NameTypeCode = new ID { Value = "XCN.NameTypeCode" },
                IdentifierCheckDigit = new ST { Value = "XCN.IdentifierCheckDigit" },
                CheckDigitScheme = new ID { Value = "XCN.CheckDigitScheme" },
                IdentifierTypeCode = new ID { Value = "XCN.IdentifierTypeCode" },
                AssigningFacility = new HD
                {
                    NamespaceId = new IS { Value = "XCN.AssigningFacility.NamespaceId" },
                    UniversalId = new ST { Value = "XCN.AssigningFacility.UniversalId" },
                    UniversalIdType = new ID { Value = "XCN.AssigningFacility.UniversalIdType" }
                },
                NameRepresentationCode = new ID { Value = "XCN.NameRepresentationCode" },
                NameContext = new CE
                {
                    Identifier = new ST { Value = "XCN.NameContext.Identifier" },
                    Text = new ST { Value = "XCN.NameContext.Text" },
                    NameofCodingSystem = new ID { Value = "XCN.NameContext.NameofCodingSystem" },
                    AlternateIdentifier1 = new ST { Value = "XCN.NameContext.AlternateIdentifier1" },
                    AlternateText1 = new ST { Value = "XCN.NameContext.AlternateText1" },
                    NameofAlternateCodingSystem1 = new ID { Value = "XCN.NameContext.NameofAlternateCodingSystem1" },
                    AlternateIdentifier2 = new ST { Value = "XCN.NameContext.AlternateIdentifier2" },
                    AlternateText2 = new ST { Value = "XCN.NameContext.AlternateText2" },
                    NameofAlternateCodingSystem2 = new ID { Value = "XCN.NameContext.NameofAlternateCodingSystem2" }
                },
                NameValidityRange = new DR
                {
                    RangeStartDateTime = new TS
                    {
                        Time = new DTM(2015, 9, 6, 9, 42, 12),
                        DegreeOfPrecision = new ID { Value = "XCN.NameValidityRange.RangeStartDateTime.DegreeOfPrecision" }
                    },
                    RangeEndDateTime = new TS
                    {
                        Time = new DTM(2015, 9, 7, 23, 59, 59, 999, 9, -4),
                        DegreeOfPrecision = new ID { Value = "XCN.NameValidityRange.RangeEndDateTime.DegreeOfPrecision" }
                    }
                },
                NameAssemblyOrder = new ID { Value = "XCN.NameAssemblyOrder" },
                EffectiveDate = new TS
                {
                    Time = new DTM(2015, 9, 6, 9, 42, 12),
                    DegreeOfPrecision = new ID { Value = "XCN.EffectiveDate.DegreeOfPrecision" }
                },
                ExpirationDate = new TS
                {
                    Time = new DTM(2015, 9, 6, 9, 42, 12),
                    DegreeOfPrecision = new ID { Value = "XCN.ExpirationDate.DegreeOfPrecision" }

                },
                ProfessionalSuffix = new ST { Value = "XCN.ProfessionalSuffix" },
                AssigningJurisdiction = new CWE
                {
                    Identifier = new ST { Value = "XCN.AssigningJurisdiction.Identifier" },
                    Text = new ST { Value = "XCN.AssigningJurisdiction.Text" },
                    NameofCodingSystem = new ID { Value = "XCN.AssigningJurisdiction.NameofCodingSystem" },
                    AlternateIdentifier = new ST { Value = "XCN.AssigningJurisdiction.AlternateIdentifier" },
                    AlternateText = new ST { Value = "XCN.AssigningJurisdiction.AlternateText" },
                    NameofAlternateCodingSystem = new ID { Value = "XCN.AssigningJurisdiction.NameofAlternateCodingSystem" },
                    CodingSystemVersionId = new ST { Value = "XCN.AssigningJurisdiction.CodingSystemVersionId" },
                    AlternateCodingSystemVersionId = new ST { Value = "XCN.AssigningJurisdiction.AlternateCodingSystemVersionId" },
                    OriginalText = new ST { Value = "XCN.AssigningJurisdiction.OriginalText" }
                },
                AssigningAgencyOrDepartment = new CWE
                {
                    Identifier = new ST { Value = "XCN.AssigningAgencyOrDepartment.Identifier" },
                    Text = new ST { Value = "XCN.AssigningAgencyOrDepartment.Text" },
                    NameofCodingSystem = new ID { Value = "XCN.AssigningAgencyOrDepartment.NameofCodingSystem" },
                    AlternateIdentifier = new ST { Value = "XCN.AssigningAgencyOrDepartment.AlternateIdentifier" },
                    AlternateText = new ST { Value = "XCN.AssigningAgencyOrDepartment.AlternateText" },
                    NameofAlternateCodingSystem = new ID { Value = "XCN.AssigningAgencyOrDepartment.NameofAlternateCodingSystem" },
                    CodingSystemVersionId = new ST { Value = "XCN.AssigningAgencyOrDepartment.CodingSystemVersionId" },
                    AlternateCodingSystemVersionId = new ST { Value = "XCN.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId" },
                    OriginalText = new ST { Value = "XCN.AssigningAgencyOrDepartment.OriginalText" }
                }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new XCN
            {
                IdNumber = new ST { Value = "XCN.IdNumber" },
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new XCN
            {
                AssigningAgencyOrDepartment = new CWE
                {
                    OriginalText = new ST { Value = "XCN.AssigningAgencyOrDepartment.OriginalText" }
                }
            };
            Assert.AreEqual(Last, field.ToString());
        }


        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new XCN(), All);
            Assert.AreEqual("XCN.IdNumber", field.IdNumber.Value);
            Assert.AreEqual("XCN.FamilyName.Surname", field.FamilyName.Surname.Value);
            Assert.AreEqual("XCN.FamilyName.OwnSurnamePrefix", field.FamilyName.OwnSurnamePrefix.Value);
            Assert.AreEqual("XCN.FamilyName.OwnSurname", field.FamilyName.OwnSurname.Value);
            Assert.AreEqual("XCN.FamilyName.SurnamePrefixFromPartnerSpouse", field.FamilyName.SurnamePrefixFromPartnerSpouse.Value);
            Assert.AreEqual("XCN.FamilyName.SurnameFromPartnerSpouse", field.FamilyName.SurnameFromPartnerSpouse.Value);
            Assert.AreEqual("XCN.GivenName", field.GivenName.Value);
            Assert.AreEqual("XCN.SecondandFurtherGivenNames", field.SecondandFurtherGivenNames.Value);
            Assert.AreEqual("XCN.Suffix", field.Suffix.Value);
            Assert.AreEqual("XCN.Prefix", field.Prefix.Value);
            Assert.AreEqual("XCN.Degree", field.Degree.Value);
            Assert.AreEqual("XCN.SourceTable", field.SourceTable.Value);
            Assert.AreEqual("XCN.AssigningAuthority.NamespaceId", field.AssigningAuthority.NamespaceId.Value);
            Assert.AreEqual("XCN.AssigningAuthority.UniversalId", field.AssigningAuthority.UniversalId.Value);
            Assert.AreEqual("XCN.AssigningAuthority.UniversalIdType", field.AssigningAuthority.UniversalIdType.Value);
            
            Assert.AreEqual("XCN.NameTypeCode", field.NameTypeCode.Value);
            Assert.AreEqual("XCN.IdentifierCheckDigit", field.IdentifierCheckDigit.Value);
            Assert.AreEqual("XCN.CheckDigitScheme", field.CheckDigitScheme.Value);
            Assert.AreEqual("XCN.IdentifierTypeCode", field.IdentifierTypeCode.Value);
            Assert.AreEqual("XCN.AssigningFacility.NamespaceId", field.AssigningFacility.NamespaceId.Value);
            Assert.AreEqual("XCN.AssigningFacility.UniversalId", field.AssigningFacility.UniversalId.Value);
            Assert.AreEqual("XCN.AssigningFacility.UniversalIdType", field.AssigningFacility.UniversalIdType.Value);
            Assert.AreEqual("XCN.NameRepresentationCode", field.NameRepresentationCode.Value);
            Assert.AreEqual("XCN.NameContext.Identifier", field.NameContext.Identifier.Value);
            Assert.AreEqual("XCN.NameContext.Text", field.NameContext.Text.Value);
            Assert.AreEqual("XCN.NameContext.NameofCodingSystem", field.NameContext.NameofCodingSystem.Value);
            Assert.AreEqual("XCN.NameContext.AlternateIdentifier1", field.NameContext.AlternateIdentifier1.Value);
            Assert.AreEqual("XCN.NameContext.AlternateText1", field.NameContext.AlternateText1.Value);
            Assert.AreEqual("XCN.NameContext.NameofAlternateCodingSystem1", field.NameContext.NameofAlternateCodingSystem1.Value);
            Assert.AreEqual("XCN.NameContext.AlternateIdentifier2", field.NameContext.AlternateIdentifier2.Value);
            Assert.AreEqual("XCN.NameContext.AlternateText2", field.NameContext.AlternateText2.Value);
            Assert.AreEqual("XCN.NameContext.NameofAlternateCodingSystem2", field.NameContext.NameofAlternateCodingSystem2.Value);

            Assert.AreEqual("20150906094212", field.NameValidityRange.RangeStartDateTime.Time.Value);
            Assert.IsNull(field.NameValidityRange.RangeStartDateTime.DegreeOfPrecision);
            Assert.AreEqual("20150907235959.9999-0400", field.NameValidityRange.RangeEndDateTime.Time.Value);
            Assert.IsNull(field.NameValidityRange.RangeEndDateTime.DegreeOfPrecision);

            Assert.AreEqual("XCN.NameAssemblyOrder", field.NameAssemblyOrder.Value);

            Assert.AreEqual("20150906094212", field.EffectiveDate.Time.Value);
            Assert.AreEqual("XCN.EffectiveDate.DegreeOfPrecision", field.EffectiveDate.DegreeOfPrecision.Value);
            Assert.AreEqual("20150906094212", field.ExpirationDate.Time.Value);
            Assert.AreEqual("XCN.ExpirationDate.DegreeOfPrecision", field.ExpirationDate.DegreeOfPrecision.Value);

            Assert.AreEqual("XCN.ProfessionalSuffix", field.ProfessionalSuffix.Value);
            
            Assert.AreEqual("XCN.AssigningJurisdiction.Identifier", field.AssigningJurisdiction.Identifier.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.Text", field.AssigningJurisdiction.Text.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.NameofCodingSystem", field.AssigningJurisdiction.NameofCodingSystem.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.AlternateIdentifier", field.AssigningJurisdiction.AlternateIdentifier.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.AlternateText", field.AssigningJurisdiction.AlternateText.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.NameofAlternateCodingSystem", field.AssigningJurisdiction.NameofAlternateCodingSystem.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.CodingSystemVersionId", field.AssigningJurisdiction.CodingSystemVersionId.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.AlternateCodingSystemVersionId", field.AssigningJurisdiction.AlternateCodingSystemVersionId.Value);
            Assert.AreEqual("XCN.AssigningJurisdiction.OriginalText", field.AssigningJurisdiction.OriginalText.Value);

            
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.Identifier", field.AssigningAgencyOrDepartment.Identifier.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.Text", field.AssigningAgencyOrDepartment.Text.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.NameofCodingSystem", field.AssigningAgencyOrDepartment.NameofCodingSystem.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.AlternateIdentifier", field.AssigningAgencyOrDepartment.AlternateIdentifier.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.AlternateText", field.AssigningAgencyOrDepartment.AlternateText.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.NameofAlternateCodingSystem", field.AssigningAgencyOrDepartment.NameofAlternateCodingSystem.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.CodingSystemVersionId", field.AssigningAgencyOrDepartment.CodingSystemVersionId.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId", field.AssigningAgencyOrDepartment.AlternateCodingSystemVersionId.Value);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.OriginalText", field.AssigningAgencyOrDepartment.OriginalText.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new XCN(), First);
            Assert.AreEqual("XCN.IdNumber", field.IdNumber.Value);
            Assert.IsNull(field.FamilyName);
            Assert.IsNull(field.GivenName);
            Assert.IsNull(field.SecondandFurtherGivenNames);
            Assert.IsNull(field.Suffix);
            Assert.IsNull(field.Prefix);
            Assert.IsNull(field.Degree);
            Assert.IsNull(field.SourceTable);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.NameTypeCode);
            Assert.IsNull(field.IdentifierCheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.NameRepresentationCode);
            Assert.IsNull(field.NameContext);
            Assert.IsNull(field.NameValidityRange);
            Assert.IsNull(field.NameAssemblyOrder);
            Assert.IsNull(field.EffectiveDate);
            Assert.IsNull(field.ExpirationDate);
            Assert.IsNull(field.ProfessionalSuffix);
            Assert.IsNull(field.AssigningJurisdiction);
            Assert.IsNull(field.AssigningAgencyOrDepartment);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new XCN(), Last);
            Assert.IsNull(field.IdNumber);
            Assert.IsNull(field.FamilyName);
            Assert.IsNull(field.GivenName);
            Assert.IsNull(field.SecondandFurtherGivenNames);
            Assert.IsNull(field.Suffix);
            Assert.IsNull(field.Prefix);
            Assert.IsNull(field.Degree);
            Assert.IsNull(field.SourceTable);
            Assert.IsNull(field.AssigningAuthority);
            Assert.IsNull(field.NameTypeCode);
            Assert.IsNull(field.IdentifierCheckDigit);
            Assert.IsNull(field.CheckDigitScheme);
            Assert.IsNull(field.IdentifierTypeCode);
            Assert.IsNull(field.AssigningFacility);
            Assert.IsNull(field.NameRepresentationCode);
            Assert.IsNull(field.NameContext);
            Assert.IsNull(field.NameValidityRange);
            Assert.IsNull(field.NameAssemblyOrder);
            Assert.IsNull(field.EffectiveDate);
            Assert.IsNull(field.ExpirationDate);
            Assert.IsNull(field.ProfessionalSuffix);
            Assert.IsNull(field.AssigningJurisdiction);
            Assert.AreEqual("XCN.AssigningAgencyOrDepartment.OriginalText", field.AssigningAgencyOrDepartment.OriginalText.Value);
        }
    }
}
