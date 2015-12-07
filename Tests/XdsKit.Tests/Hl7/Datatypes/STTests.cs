using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class STTests
    {
        [Test]
        public void Should_Encode_Empty()
        {
            var st = new ST { Value = "" };
            Assert.AreEqual("", st.Encode());
        }

        [Test]
        public void Should_Encode_null()
        {
            var st = new ST { Value = null };
            Assert.AreEqual("", st.Encode());
        }

        [Test]
        public void Should_Encode()
        {
            var st = new ST { Value = "This is an ST" };
            Assert.AreEqual("This is an ST", st.Encode());
        }

        [Test]
        public void Should_Parse_Empty()
        {
            var id = DataType.Parse(new ST(), "\"\"");
            Assert.AreEqual("", id.Value);
        }

        [Test]
        public void Should_Parse_null()
        {
            var id = DataType.Parse(new ST(), null);
            Assert.IsNull(id.Value);
        }

        [Test]
        public void Should_Parse()
        {
            var id = DataType.Parse(new ST(), "This is an ST");
            Assert.AreEqual("This is an ST", id.Value);
        }
    }
}
