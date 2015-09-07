using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class NMTests
    {
        [Test]
        public void Should_Encode_Zero()
        {
            var nm = new NM { Value = decimal.Zero };
            Assert.AreEqual("0", nm.Encode());
        }

        [Test]
        public void Should_Encode_null()
        {
            var nm = new NM { Value = null };
            Assert.AreEqual("", nm.Encode());
        }

        [Test]
        public void Should_Encode()
        {
            var nm = new NM { Value = 710m };
            Assert.AreEqual("710", nm.Encode());
        }

        [Test]
        public void Should_Encode_decimals()
        {
            var nm = new NM { Value = 710.020m };
            Assert.AreEqual("710.020", nm.Encode());
            nm = new NM { Value = 0.020m };
            Assert.AreEqual("0.020", nm.Encode());
            nm = new NM { Value = -0.020m };
            Assert.AreEqual("-0.020", nm.Encode());
            nm = new NM { Value = .020m };
            Assert.AreEqual("0.020", nm.Encode());
        }


        [Test]
        public void Should_Parse_Empty()
        {
            var id = DataType.Parse(new NM(), "\"\"");
            Assert.AreEqual(null, id.Value);
        }

        [Test]
        public void Should_Parse_null()
        {
            var id = DataType.Parse(new NM(), null);
            Assert.IsNull(id.Value);
        }

        [Test]
        public void Should_Parse()
        {
            var id = DataType.Parse(new NM(), "710");
            Assert.AreEqual(710m, id.Value);
        }

        [Test]
        public void Should_Parse_decimals()
        {
            var nm = DataType.Parse(new NM(), "710.020");
            Assert.AreEqual(710.020m, nm.Value);
            nm = DataType.Parse(new NM(), "0.020");
            Assert.AreEqual(0.020m, nm.Value);
            nm = DataType.Parse(new NM(), "-0.020");
            Assert.AreEqual(-0.020m, nm.Value);
            nm = DataType.Parse(new NM(), ".020");
            Assert.AreEqual(.020m, nm.Value);
        }
    }
}
