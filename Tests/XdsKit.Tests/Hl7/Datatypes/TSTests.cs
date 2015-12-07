using NUnit.Framework;

using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class TSTests
    {
        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new TS
            {
                Time = new DTM(2015, 9, 6, 9, 42, 12),
                DegreeOfPrecision = new ID { Value = "TS.DegreeOfPrecision" }
            };
            Assert.AreEqual("20150906094212^TS.DegreeOfPrecision", field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new TS
            {
                Time = new DTM(2015, 9, 6, 9, 42, 12),
            };
            Assert.AreEqual("20150906094212", field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new TS
            {
                DegreeOfPrecision = new ID { Value = "TS.DegreeOfPrecision" }
            };
            Assert.AreEqual("^TS.DegreeOfPrecision", field.ToString());
        }
    }
}
