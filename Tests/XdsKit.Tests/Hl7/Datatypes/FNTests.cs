using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class FNTests
    {
        public string All = "FN.Surname^FN.OwnSurnamePrefix^FN.OwnSurname^FN.SurnamePrefixFromPartnerSpouse^FN.SurnameFromPartnerSpouse";
        public string First = "FN.Surname";
        public string Last = "^^^^FN.SurnameFromPartnerSpouse";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new FN
            {
                Surname = new ST { Value = "FN.Surname" },
                OwnSurnamePrefix = new ST { Value = "FN.OwnSurnamePrefix" },
                OwnSurname = new ST { Value = "FN.OwnSurname" },
                SurnamePrefixFromPartnerSpouse = new ST { Value = "FN.SurnamePrefixFromPartnerSpouse" },
                SurnameFromPartnerSpouse = new ST { Value = "FN.SurnameFromPartnerSpouse" }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new FN
            {
                Surname = new ST { Value = "FN.Surname" },
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new FN
            {
                SurnameFromPartnerSpouse = new ST { Value = "FN.SurnameFromPartnerSpouse" }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new FN(), All);
            Assert.AreEqual("FN.Surname", field.Surname.Value);
            Assert.AreEqual("FN.OwnSurnamePrefix", field.OwnSurnamePrefix.Value);
            Assert.AreEqual("FN.OwnSurname", field.OwnSurname.Value);
            Assert.AreEqual("FN.SurnamePrefixFromPartnerSpouse", field.SurnamePrefixFromPartnerSpouse.Value);
            Assert.AreEqual("FN.SurnameFromPartnerSpouse", field.SurnameFromPartnerSpouse.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new FN(), First);
            Assert.AreEqual("FN.Surname", field.Surname.Value);
            Assert.IsNull(field.OwnSurnamePrefix);
            Assert.IsNull(field.OwnSurname);
            Assert.IsNull(field.SurnamePrefixFromPartnerSpouse);
            Assert.IsNull(field.SurnameFromPartnerSpouse);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new FN(), Last);
            Assert.IsNull(field.Surname);
            Assert.IsNull(field.OwnSurnamePrefix);
            Assert.IsNull(field.OwnSurname);
            Assert.IsNull(field.SurnamePrefixFromPartnerSpouse);
            Assert.AreEqual("FN.SurnameFromPartnerSpouse", field.SurnameFromPartnerSpouse.Value);
        }
    }
}
