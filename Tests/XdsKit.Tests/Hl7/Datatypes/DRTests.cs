using NUnit.Framework;
using XdsKit.Hl7;
using XdsKit.Hl7.Datatypes;

namespace XdsKit.Tests.Hl7.Datatypes
{
    [TestFixture]
    public class DRTests
    {
        public string All = "20150906094212&DR.RangeStartDateTime.DegreeOfPrecision^20150907235959.9999-0400&DR.RangeEndDateTime.DegreeOfPrecision";
        public string First = "20150906094212";
        public string Last = "^&DR.RangeEndDateTime.DegreeOfPrecision";

        [Test]
        public void Should_Serialize_AllComponents()
        {
            var field = new DR
            {
                RangeStartDateTime = new TS
                {
                    Time = new DTM(2015, 9, 6, 9, 42, 12),
                    DegreeOfPrecision = new ID { Value = "DR.RangeStartDateTime.DegreeOfPrecision" }
                },
                RangeEndDateTime = new TS
                {
                    Time = new DTM(2015, 9, 7, 23, 59, 59, 999, 9, -4),
                    DegreeOfPrecision = new ID { Value = "DR.RangeEndDateTime.DegreeOfPrecision" }
                }
            };
            Assert.AreEqual(All, field.ToString());
        }

        [Test]
        public void Should_Serialize_FirstComponent()
        {
            var field = new DR
            {
                RangeStartDateTime = new TS { Time = new DTM(2015, 9, 6, 9, 42, 12) }
            };
            Assert.AreEqual(First, field.ToString());
        }

        [Test]
        public void Should_Serialize_LastComponent()
        {
            var field = new DR
            {
                RangeEndDateTime = new TS
                {
                    DegreeOfPrecision = new ID { Value = "DR.RangeEndDateTime.DegreeOfPrecision" }
                }
            };
            Assert.AreEqual(Last, field.ToString());
        }

        [Test]
        public void Should_Parse_AllComponents()
        {
            var field = DataType.Parse(new DR(), All);
            Assert.AreEqual("20150906094212", field.RangeStartDateTime.Time.Value);
            Assert.AreEqual("DR.RangeStartDateTime.DegreeOfPrecision", field.RangeStartDateTime.DegreeOfPrecision.Value);
            Assert.AreEqual("20150907235959.9999-0400", field.RangeEndDateTime.Time.Value);
            Assert.AreEqual("DR.RangeEndDateTime.DegreeOfPrecision", field.RangeEndDateTime.DegreeOfPrecision.Value);
        }

        [Test]
        public void Should_Parse_FirstComponents()
        {
            var field = DataType.Parse(new DR(), First);
            Assert.AreEqual("20150906094212", field.RangeStartDateTime.Time.Value);
            Assert.IsNull(field.RangeStartDateTime.DegreeOfPrecision);
            Assert.IsNull(field.RangeEndDateTime);
        }

        [Test]
        public void Should_Parse_LastComponents()
        {
            var field = DataType.Parse(new DR(), Last);
            Assert.IsNull(field.RangeStartDateTime);
            Assert.AreEqual("DR.RangeEndDateTime.DegreeOfPrecision", field.RangeEndDateTime.DegreeOfPrecision.Value);
        }
    }
}
