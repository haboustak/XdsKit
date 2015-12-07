using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class ISTests
    {
        [Test]
        public void Should_Encode_Empty()
        {
            var id = new IS { Value = "" };
            Assert.AreEqual("", id.Encode());
        }

        [Test]
        public void Should_Encode_null()
        {
            var id = new IS { Value = null };
            Assert.AreEqual("", id.Encode());
        }

        [Test]
        public void Should_Encode()
        {
            var id = new IS { Value = "This is an IS" };
            Assert.AreEqual("This is an IS", id.Encode());
        }

        [Test]
        public void Should_Parse_Empty()
        {
            var id = DataType.Parse(new IS(), "\"\"");
            Assert.AreEqual("", id.Value);
        }

        [Test]
        public void Should_Parse_null()
        {
            var id = DataType.Parse(new IS(), null);
            Assert.IsNull(id.Value);
        }

        [Test]
        public void Should_Parse()
        {
            var id = DataType.Parse(new IS(), "This is an IS");
            Assert.AreEqual("This is an IS", id.Value);
        }
    }
}
