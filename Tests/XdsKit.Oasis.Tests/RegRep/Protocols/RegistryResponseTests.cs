using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Protocols;

namespace XdsKit.Oasis.Tests.RegRep.Protocols
{
    [TestFixture]
    public class RegistryResponseTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var response = Resource.Deserialize<RegistryResponse>("Resources.Protocols.RegistryResponse_Test01.xml");
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", response.RequestId);
            Assert.AreEqual(ResponseStatus.PartialSuccess, response.Status);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ResponseStatusType:PartialSuccess", response.StatusValue);
            Assert.AreEqual(ResponseStatus.PartialSuccess, response.Status);

            Assert.AreEqual(4, response.Slots.Count);
            AssertSlot(response.Slots[0], "creationTime", "urn:xdskit:com:c7ptmx37tfbcwy8ky7b", new[] { "2015-01-01" });
            AssertSlot(response.Slots[1], "languageCode", "urn:xdskit:com:c7ptmx37tfbcwy8ky7c", new[] { "en-US", "en-GB", "en-AU" });
            AssertSlot(response.Slots[2], "serviceStartTime", "", new[] { "2015-01-01T09:00:00" });
            AssertSlot(response.Slots[3], "serviceStopTime", "", new[] { "2015-01-01T21:00:00" });

            Assert.AreEqual(ErrorSeverity.Error, response.RegistryErrors.HighestSeverity);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ErrorSeverityType:Error", response.RegistryErrors.HighestSeverityValue);
            Assert.AreEqual(2, response.RegistryErrors.Errors.Count);
            AssertError(response.RegistryErrors.Errors[0], "ObjectRefIdNotFound", "A local object refererence (urn:xdskit:com:c7ptmx37tfbcwy8ky70) was not found.", "Line 1022, Column 7", ErrorSeverity.Error);
            AssertError(response.RegistryErrors.Errors[1], "RegistryError", "RegistryPackage has too many items. Performance degraded", "", ErrorSeverity.Warning);
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Protocols.RegistryResponse_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryResponse>();
            list.DeepEquals(list2);
        }

        private RegistryResponse Build_Test01()
        {
            var request = new RegistryResponse
            {
                RequestId = "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                Status = ResponseStatus.PartialSuccess,
                Slots = new List<Slot>
                {
                    new Slot
                    {
                        Name = "creationTime",
                        Type = "urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                        Values = new List<string> {"2015-01-01"}
                    },
                    new Slot
                    {
                        Name = "languageCode",
                        Type = "urn:xdskit:com:c7ptmx37tfbcwy8ky7c",
                        Values = new List<string> {"en-US", "en-GB", "en-AU"}
                    },
                    new Slot
                    {
                        Name = "serviceStartTime",
                        Values = new List<string> {"2015-01-01T09:00:00"}
                    },
                    new Slot
                    {
                        Name = "serviceStopTime",
                        Values = new List<string> {"2015-01-01T21:00:00"}
                    }
                },
                RegistryErrors = new RegistryErrorList
                {
                    HighestSeverity = ErrorSeverity.Error,
                    Errors = new List<RegistryError>
                    {
                        new RegistryError
                        {
                            ErrorCode = "ObjectRefIdNotFound",
                            CodeContext =
                                "A local object refererence (urn:xdskit:com:c7ptmx37tfbcwy8ky70) was not found.",
                            Location = "Line 1022, Column 7",
                            Severity =  ErrorSeverity.Error
                        },
                        new RegistryError
                        {
                            ErrorCode = "RegistryError",
                            CodeContext = "RegistryPackage has too many items. Performance degraded",
                            Severity = ErrorSeverity.Warning
                        }
                    }
                }
            };

            return request;
        }

        private void AssertSlot(Slot slot, string name, string type, IList<string> values)
        {
            Assert.AreEqual(name ?? "", slot.Name ?? "");
            Assert.AreEqual(type ?? "", slot.Type ?? "");

            Assert.AreEqual(values.Count, slot.Values.Count);
            for (var i = 0; i < values.Count; i++)
                Assert.AreEqual(values[i], slot.Values[i]);
        }

        private void AssertError(RegistryError error, 
            string errorCode, string codeContext, string location, ErrorSeverity severity)
        {
            Assert.AreEqual(errorCode ?? "", error.ErrorCode ?? "");
            Assert.AreEqual(codeContext ?? "", error.CodeContext ?? "");
            Assert.AreEqual(location ?? "", error.Location ?? "");
            Assert.AreEqual(severity, error.Severity);
        }
    }
}