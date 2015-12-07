using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class CETests
    {
        private const string All = "CE.Identifier^CE.Text^CE.NameofCodingSystem^CE.AlternateIdentifier1^CE.AlternateText1^CE.NameofAlternateCodingSystem1^CE.AlternateIdentifier2^CE.AlternateText2^CE.NameofAlternateCodingSystem2";
        private const string First = "CE.Identifier";
        private const string Last = "^^^^^^^^CE.NameofAlternateCodingSystem2";
        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new CE
            {
                Identifier = new ST {Value = "CE.Identifier"},
                Text = new ST {Value = "CE.Text"},
                NameofCodingSystem = new ID { Value = "CE.NameofCodingSystem" },
                AlternateIdentifier1 = new ST { Value = "CE.AlternateIdentifier1" },
                AlternateText1 = new ST { Value = "CE.AlternateText1" },
                NameofAlternateCodingSystem1 = new ID { Value = "CE.NameofAlternateCodingSystem1" },
                AlternateIdentifier2 = new ST { Value = "CE.AlternateIdentifier2" },
                AlternateText2 = new ST { Value = "CE.AlternateText2" },
                NameofAlternateCodingSystem2 = new ID { Value = "CE.NameofAlternateCodingSystem2" }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new CE
            {
                Identifier = new ST { Value = "CE.Identifier" }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new CE
            {
                NameofAlternateCodingSystem2 = new ID { Value = "CE.NameofAlternateCodingSystem2" }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new CE(), All);
            Assert.AreEqual("CE.Identifier", field.Identifier.Value);
            Assert.AreEqual("CE.NameofCodingSystem", field.NameofCodingSystem.Value);
            Assert.AreEqual("CE.AlternateIdentifier1", field.AlternateIdentifier1.Value);
            Assert.AreEqual("CE.AlternateText1", field.AlternateText1.Value);
            Assert.AreEqual("CE.NameofAlternateCodingSystem1", field.NameofAlternateCodingSystem1.Value);
            Assert.AreEqual("CE.AlternateIdentifier2", field.AlternateIdentifier2.Value);
            Assert.AreEqual("CE.AlternateText2", field.AlternateText2.Value);
            Assert.AreEqual("CE.NameofAlternateCodingSystem2", field.NameofAlternateCodingSystem2.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new CE(), First);
            Assert.AreEqual("CE.Identifier", field.Identifier.Value);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.AlternateIdentifier1);
            Assert.IsNull(field.AlternateText1);
            Assert.IsNull(field.NameofAlternateCodingSystem1);
            Assert.IsNull(field.AlternateIdentifier2);
            Assert.IsNull(field.AlternateText2);
            Assert.IsNull(field.NameofAlternateCodingSystem2);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new CE(), Last);
            Assert.IsNull(field.Identifier);
            Assert.IsNull(field.NameofCodingSystem);
            Assert.IsNull(field.AlternateIdentifier1);
            Assert.IsNull(field.AlternateText1);
            Assert.IsNull(field.NameofAlternateCodingSystem1);
            Assert.IsNull(field.AlternateIdentifier2);
            Assert.IsNull(field.AlternateText2);
            Assert.AreEqual("CE.NameofAlternateCodingSystem2", field.NameofAlternateCodingSystem2.Value);
        }
    }
}
