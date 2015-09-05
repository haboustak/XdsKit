using System;
using System.Collections.Generic;
using System.Xml.Linq;

using NUnit.Framework;

using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class EventModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.EventModel_Test01.xml");

            Assert.AreEqual(1, list.Subscriptions.Count);

            var subscription = list.Subscriptions[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", subscription.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Subscription", subscription.ObjectType);
            Assert.AreEqual("urn:xdskit:com:query:c7ptmx37tfbcwy8ky7o", subscription.Selector);
            Assert.AreEqual(new DateTime(2015, 1, 1, 9, 0, 0), subscription.StartTime);
            Assert.AreEqual(true, subscription.StartTimeSpecified);
            Assert.AreEqual(DateTime.MinValue, subscription.EndTime);
            Assert.AreEqual(false, subscription.EndTimeSpecified);
            Assert.AreEqual(new TimeSpan(1, 0, 0), subscription.NotificationInterval);

            Assert.AreEqual(2, subscription.NotifyActions.Count);
            OasisAssert.NotifyAction(subscription.NotifyActions[0], 
                "mailto:haboustak@xdskit.com",
                "urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:Objects");
            Assert.AreEqual(true, subscription.NotifyActions[0].NotificationOptionSpecified);
            OasisAssert.NotifyAction(subscription.NotifyActions[1],
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7n",
                "urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:ObjectRefs");
            Assert.AreEqual(false, subscription.NotifyActions[1].NotificationOptionSpecified);

            Assert.AreEqual(1, list.AdhocQueries.Count);
            var query = list.AdhocQueries[0];
            Assert.AreEqual("urn:xdskit:com:query:c7ptmx37tfbcwy8ky7o", query.Id);
            Assert.AreEqual("urn:oasis:names:tc:ebxml-regrep:QueryLanguage:SQL-92", query.QueryExpression.QueryLanguage);
            Assert.AreEqual("select * from RegistryObjects where id='urn:it:is:1992'", query.QueryExpression.Query.Trim());
        }

        [Test]
        public void Should_Serialize_Test01()
        {
            var list = Build_Test01();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.EventModel_Test01.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test01()
        {
            var list = Build_Test01();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test01()
        {
            var list = new RegistryObjectList
            {
                Subscriptions = new List<Subscription>
                {
                    new Subscription
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        ObjectType="urn:oasis:names:tc:ebxml-regrep:ObjectType:RegistryObject:Subscription",
                        Selector="urn:xdskit:com:query:c7ptmx37tfbcwy8ky7o",
                        StartTime=DateTime.Parse("2015-01-01T09:00:00"),
                        NotificationInterval="PT1H".AsTimeSpan(),
                        NotifyActions = new List<NotifyAction>
                        {
                            new NotifyAction
                            {
                                Endpoint="mailto:haboustak@xdskit.com",
                                NotificationOption="urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:Objects"
                            },
                            new NotifyAction
                            {
                                Endpoint="urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                            }
                        }
                    }
                },
                AdhocQueries = new List<AdhocQuery>
                {
                    new AdhocQuery
                    {
                        Id="urn:xdskit:com:query:c7ptmx37tfbcwy8ky7o",
                        QueryExpression = new QueryExpression
                        {
                             QueryLanguage="urn:oasis:names:tc:ebxml-regrep:QueryLanguage:SQL-92",
                             Query="select * from RegistryObjects where id='urn:it:is:1992'"
                        }
                    }
                }
            };

            return list;
        }

        [Test]
        public void Should_Deserialize_Test02()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.EventModel_Test02.xml");

            Assert.AreEqual(1, list.Notifications.Count);
            var notification = list.Notifications[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", notification.Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", notification.Subscription);
            Assert.AreEqual(2, notification.RegistryObjects.ObjectReferences.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7n", notification.RegistryObjects.ObjectReferences[0].Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7p", notification.RegistryObjects.ObjectReferences[1].Id);
        }

        [Test]
        public void Should_Serialize_Test02()
        {
            var list = Build_Test02();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.EventModel_Test02.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test02()
        {
            var list = Build_Test02();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test02()
        {
            var list = new RegistryObjectList
            {
                Notifications = new List<Notification>
                {
                    new Notification
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                        Subscription="urn:xdskit:com:c7ptmx37tfbcwy8ky7m",
                        RegistryObjects = new RegistryObjectList
                        {
                            ObjectReferences = new List<ObjectRef>
                            {
                                new ObjectRef
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7n"
                                },
                                new ObjectRef
                                {
                                    Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7p"
                                }
                            }
                        }
                    }
                }
            };

            return list;
        }

        [Test]
        public void Should_Deserialize_Test03()
        {
            var list = Resource.Deserialize<RegistryObjectList>("Resources.Models.EventModel_Test03.xml");

            Assert.AreEqual(2, list.AuditableEvents.Count);
            var audit = list.AuditableEvents[0];
            OasisAssert.AuditableEvent(audit,
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                "urn:oasis:names:tc:ebxml-regrep:EventType:Created", 
                new DateTime(2015,08,31,6,49,22),
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7c");
            Assert.AreEqual(2, audit.AffectedObjects.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7n", audit.AffectedObjects[0].Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7p", audit.AffectedObjects[1].Id);

            audit = list.AuditableEvents[1];
            OasisAssert.AuditableEvent(audit,
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7d",
                "urn:oasis:names:tc:ebxml-regrep:EventType:Deleted",
                new DateTime(2015, 08, 31, 6, 52, 07),
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7e",
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7f");
            Assert.AreEqual(1, audit.AffectedObjects.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", audit.AffectedObjects[0].Id);
        }

        [Test]
        public void Should_Serialize_Test03()
        {
            var list = Build_Test03();
            list.ToXml()
                .AssertByLine(XDocument.Parse(Resource.Get("Resources.Models.EventModel_Test03.xml")));
        }

        [Test]
        public void Should_Parse_Serialized_Test03()
        {
            var list = Build_Test03();
            var xml = list.ToXml().ToString();

            var list2 = xml.FromXml<RegistryObjectList>();
            list.DeepEquals(list2);
        }

        private RegistryObjectList Build_Test03()
        {
            var list = new RegistryObjectList
            {
                AuditableEvents = new List<AuditableEvent>
                {
                    new AuditableEvent
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                        EventType="urn:oasis:names:tc:ebxml-regrep:EventType:Created",
                        Timestamp=DateTime.Parse("2015-08-31T06:49:22"),
                        User="urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                        RequestId="urn:xdskit:com:c7ptmx37tfbcwy8ky7c",
                        AffectedObjects = new List<ObjectRef>
                        {
                            new ObjectRef { Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7n" },
                            new ObjectRef { Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7p" }
                        }
                    },
                    new AuditableEvent
                    {
                        Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7d",
                        EventType="urn:oasis:names:tc:ebxml-regrep:EventType:Deleted",
                        Timestamp=DateTime.Parse("2015-08-31T06:52:07"),
                        User="urn:xdskit:com:c7ptmx37tfbcwy8ky7e",
                        RequestId="urn:xdskit:com:c7ptmx37tfbcwy8ky7f",
                        AffectedObjects = new List<ObjectRef>
                        {
                            new ObjectRef { Id="urn:xdskit:com:c7ptmx37tfbcwy8ky7m" }
                        }
                    }
                }
            };

            return list;
        }
    }
}
