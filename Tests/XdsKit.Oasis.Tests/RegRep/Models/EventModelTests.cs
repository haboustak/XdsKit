
using System;
using System.Runtime;
using NUnit.Framework;
using System.Xml.Serialization;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Oasis.Tests.RegRep.Models
{
    [TestFixture]
    public class EventModelTests
    {
        [Test]
        public void Should_Deserialize_Test01()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.EventModel_Test01.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

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
            AssertNotifyAction(subscription.NotifyActions[0], 
                "mailto:haboustak@xdskit.com",
                "urn:oasis:names:tc:ebxml-regrep:NotificationOptionType:Objects");
            Assert.AreEqual(true, subscription.NotifyActions[0].NotificationOptionSpecified);
            AssertNotifyAction(subscription.NotifyActions[1],
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
        public void Should_Deserialize_Test02()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.EventModel_Test02.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

            Assert.AreEqual(1, list.Notifications.Count);
            var notification = list.Notifications[0];
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7a", notification.Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", notification.Subscription);
            Assert.AreEqual(2, notification.RegistryObjects.ObjectReferences.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7n", notification.RegistryObjects.ObjectReferences[0].Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7p", notification.RegistryObjects.ObjectReferences[1].Id);
        }

        [Test]
        public void Should_Deserialize_Test03()
        {
            var list = Resource.Deserialize<RegistryObjectList>(
                "Resources.EventModel_Test03.xml",
                new XmlRootAttribute
                {
                    ElementName = "RegistryObjectList",
                    Namespace = Namespaces.Rim
                });

            Assert.AreEqual(2, list.AuditableEvents.Count);
            var audit = list.AuditableEvents[0];
            AssertAuditableEvent(audit,
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7a",
                "urn:oasis:names:tc:ebxml-regrep:EventType:Created", 
                new DateTime(2015,08,31,11,49,22, DateTimeKind.Utc).ToLocalTime(),
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7b",
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7c");
            Assert.AreEqual(2, audit.AffectedObjects.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7n", audit.AffectedObjects[0].Id);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7p", audit.AffectedObjects[1].Id);

            audit = list.AuditableEvents[1];
            AssertAuditableEvent(audit,
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7d",
                "urn:oasis:names:tc:ebxml-regrep:EventType:Deleted",
                new DateTime(2015, 08, 31, 11, 52, 07, DateTimeKind.Utc).ToLocalTime(),
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7e",
                "urn:xdskit:com:c7ptmx37tfbcwy8ky7f");
            Assert.AreEqual(1, audit.AffectedObjects.Count);
            Assert.AreEqual("urn:xdskit:com:c7ptmx37tfbcwy8ky7m", audit.AffectedObjects[0].Id);
        }

        private void AssertNotifyAction(NotifyAction action, string endPoint, string notificationOption)
        {
            Assert.AreEqual(endPoint ?? "", action.Endpoint ?? "");
            Assert.AreEqual(notificationOption ?? "", action.NotificationOption ?? "");
        }

        private void AssertAuditableEvent(AuditableEvent audit,
            string id, string eventType, DateTime timestamp, string userId, string requestId)
        {
            Assert.AreEqual(id ?? "", audit.Id ?? "");
            Assert.AreEqual(eventType ?? "", audit.EventType ?? "");
            Assert.AreEqual(timestamp, audit.Timestamp);
            Assert.AreEqual(userId ?? "", audit.User ?? "");
            Assert.AreEqual(requestId ?? "", audit.RequestId ?? "");
        }
    }
}
