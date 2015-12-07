using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class IDTests
    {
        [Test]
        public void Should_Encode_Empty()
        {
            var id = new ID { Value = "" };
            Assert.AreEqual("", id.Encode());
        }

        [Test]
        public void Should_Encode_null()
        {
            var id = new ID { Value = null };
            Assert.AreEqual("", id.Encode());
        }

        [Test]
        public void Should_Encode()
        {
            var id = new ID { Value = "This is an ID" };
            Assert.AreEqual("This is an ID", id.Encode());
        }

        [Test]
        public void Should_Parse_Empty()
        {
            var id = DataType.Parse(new ID(), "\"\"");
            Assert.AreEqual("", id.Value);
        }

        [Test]
        public void Should_Parse_null()
        {
            var id = DataType.Parse(new ID(), null);
            Assert.IsNull(id.Value);
        }

        [Test]
        public void Should_Parse()
        {
            var id = DataType.Parse(new ID(), "This is an ID");
            Assert.AreEqual("This is an ID", id.Value);
        }
    }
}
