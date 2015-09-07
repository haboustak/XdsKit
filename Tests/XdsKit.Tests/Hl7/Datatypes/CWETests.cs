using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class CWETests
    {
        public string All = "CWE.Identifier^CWE.Text^CWE.NameofCodingSystem^CWE.AlternateIdentifier^CWE.AlternateText^CWE.NameofAlternateCodingSystem^CWE.CodingSystemVersionId^CWE.AlternateCodingSystemVersionId^CWE.OriginalText";
        public string First = "CWE.Identifier";
        public string Last = "^^^^^^^^CWE.OriginalText";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new CWE
            {
                Identifier = new ST { Value = "CWE.Identifier" },
                Text = new ST { Value = "CWE.Text" },
                NameofCodingSystem = new ID { Value = "CWE.NameofCodingSystem" },
                AlternateIdentifier = new ST { Value = "CWE.AlternateIdentifier" },
                AlternateText = new ST { Value = "CWE.AlternateText" },
                NameofAlternateCodingSystem = new ID { Value = "CWE.NameofAlternateCodingSystem" },
                CodingSystemVersionId = new ST { Value = "CWE.CodingSystemVersionId" },
                AlternateCodingSystemVersionId = new ST { Value = "CWE.AlternateCodingSystemVersionId" },
                OriginalText = new ST { Value = "CWE.OriginalText" }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new CWE
            {
                Identifier = new ST { Value = "CWE.Identifier" }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new CWE
            {
                OriginalText = new ST { Value = "CWE.OriginalText" }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new CWE(), All);
            Assert.AreEqual("CWE.Identifier", field.Identifier.Value);
            Assert.AreEqual("CWE.Text", field.Text.Value);
            Assert.AreEqual("CWE.NameofCodingSystem", field.NameofCodingSystem.Value);
            Assert.AreEqual("CWE.AlternateIdentifier", field.AlternateIdentifier.Value);
            Assert.AreEqual("CWE.AlternateText", field.AlternateText.Value);
            Assert.AreEqual("CWE.NameofAlternateCodingSystem", field.NameofAlternateCodingSystem.Value);
            Assert.AreEqual("CWE.CodingSystemVersionId", field.CodingSystemVersionId.Value);
            Assert.AreEqual("CWE.AlternateCodingSystemVersionId", field.AlternateCodingSystemVersionId.Value);
            Assert.AreEqual("CWE.OriginalText", field.OriginalText.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new CWE(), First);
            Assert.AreEqual("CWE.Identifier", field.Identifier.Value);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.Text);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.AlternateIdentifier);
            Assert.IsNull(field.AlternateText);
            Assert.IsNull(field.NameofAlternateCodingSystem);
            Assert.IsNull(field.CodingSystemVersionId);
            Assert.IsNull(field.AlternateCodingSystemVersionId);
            Assert.IsNull(field.OriginalText);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new CWE(), Last);

            Assert.IsNull(field.Identifier);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.Text);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.AlternateIdentifier);
            Assert.IsNull(field.AlternateText);
            Assert.IsNull(field.NameofAlternateCodingSystem);
            Assert.IsNull(field.CodingSystemVersionId);
            Assert.IsNull(field.AlternateCodingSystemVersionId);
            Assert.AreEqual("CWE.OriginalText", field.OriginalText.Value);
        }
    }
}
