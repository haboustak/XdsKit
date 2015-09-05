using System;
using System.Collections.Generic;
using NUnit.Framework;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;
using XdsKit.Oasis.RegRep.Services;

namespace XdsKit.Oasis.Tests
{
    public static class OasisAssert
    {
        public static void AdhocQuery(AdhocQuery query, string id)
        {
            Assert.AreEqual(id ?? "", query.Id ?? "");
        }

        public static void Association(Association association, string id, AssociationType type, string source, string target)
        {
            Assert.AreEqual(id ?? "", association.Id ?? "");
            Assert.AreEqual(type, association.AssociationType);
            Assert.AreEqual(source ?? "", association.Source ?? "");
            Assert.AreEqual(target ?? "", association.Target ?? "");
        }

        public static void AuditableEvent(AuditableEvent audit,
            string id, string eventType, DateTime timestamp, string userId, string requestId)
        {
            Assert.AreEqual(id ?? "", audit.Id ?? "");
            Assert.AreEqual(eventType ?? "", audit.EventType ?? "");
            Assert.AreEqual(timestamp, audit.Timestamp);
            Assert.AreEqual(userId ?? "", audit.User ?? "");
            Assert.AreEqual(requestId ?? "", audit.RequestId ?? "");
        }

        public static void ClassificationNode(ClassificationNode node, string id, string localId, string code,
            string name, string description)
        {

            Assert.AreEqual(id ?? "", node.Id ?? "");
            Assert.AreEqual(localId ?? "", node.LocalId ?? "");
            Assert.AreEqual(code ?? "", node.Code ?? "");
            Assert.AreEqual(name ?? "", node.Name.GetValue() ?? "");
            Assert.AreEqual(name ?? "", node.Name.GetValue("en-US") ?? "");
            Assert.AreEqual(description ?? "", node.Description.GetValue() ?? "");
            Assert.AreEqual(description ?? "", node.Description.GetValue("en-US") ?? "");
        }

        public static void Classification(Classification classification, string scheme, string objectId, string nodeId, string nodeRepresentation)
        {
            Assert.AreEqual(scheme ?? "", classification.ClassificationScheme ?? "");
            Assert.AreEqual(objectId ?? "", classification.ClassifiedObject ?? "");
            Assert.AreEqual(nodeId ?? "", classification.ClassificationNode ?? "");
            Assert.AreEqual(nodeRepresentation ?? "", classification.NodeRepresentation ?? "");
        }

        public static void ExtrinsicObject(ExtrinsicObject item,
            string id, string mimeType, string objectType, bool isOpaque)
        {
            Assert.AreEqual(id ?? "", item.Id ?? "");
            Assert.AreEqual(mimeType ?? "", item.MimeType ?? "");
            Assert.AreEqual(objectType ?? "", item.ObjectType ?? "");
            Assert.AreEqual(isOpaque, item.IsOpaque);
        }

        public static void ExternalIdentifier(ExternalIdentifier item,
            string id, string identificationScheme, string registryObject, string value, string name, string description)
        {
            Assert.AreEqual(id ?? "", item.Id ?? "");
            Assert.AreEqual(identificationScheme ?? "", item.IdentificationScheme ?? "");
            Assert.AreEqual(registryObject ?? "", item.RegistryObject ?? "");
            Assert.AreEqual(value ?? "", item.Value ?? "");
            Assert.AreEqual(name ?? "", (item.Name != null ? item.Name.GetValue() : null) ?? "");
            Assert.AreEqual(name ?? "", (item.Name != null ? item.Name.GetValue("en-US") : null) ?? "");
            Assert.AreEqual(description ?? "", (item.Description != null ? item.Description.GetValue() : null) ?? "");
            Assert.AreEqual(description ?? "", (item.Description != null ? item.Description.GetValue("en-US") : null) ?? "");
        }

        public static void NotifyAction(NotifyAction action, string endPoint, string notificationOption)
        {
            Assert.AreEqual(endPoint ?? "", action.Endpoint ?? "");
            Assert.AreEqual(notificationOption ?? "", action.NotificationOption ?? "");
        }

        public static void ObjectRef(ObjectRef action, string id, bool createReplica=false)
        {
            Assert.AreEqual(id ?? "", action.Id ?? "");
            Assert.AreEqual(action.CreateReplica, createReplica);
        }

        public static void Registry(Registry registry,
            string id, string oper, string specificationVersion, TimeSpan replicationSyncLatency, TimeSpan catalogingLatency, string conformanceProfile)
        {
            Assert.AreEqual(id ?? "", registry.Id ?? "");
            Assert.AreEqual(oper ?? "", registry.Operator ?? "");
            Assert.AreEqual(specificationVersion ?? "", registry.SpecificationVersion ?? "");
            Assert.AreEqual(replicationSyncLatency, registry.ReplicationSyncLatency);
            Assert.AreEqual(catalogingLatency, registry.CatalogingLatency);
            Assert.AreEqual(conformanceProfile ?? "", registry.ConformanceProfile ?? "");
        }

        public static void RegistryPackage(RegistryPackage item,
            string id, string name, string description)
        {
            Assert.AreEqual(id ?? "", item.Id ?? "");
            Assert.AreEqual(name ?? "", (item.Name != null ? item.Name.GetValue() : null) ?? "");
            Assert.AreEqual(name ?? "", (item.Name != null ? item.Name.GetValue("en-US") : null) ?? "");
            Assert.AreEqual(description ?? "", (item.Description != null ? item.Description.GetValue() : null) ?? "");
            Assert.AreEqual(description ?? "", (item.Description != null ? item.Description.GetValue("en-US") : null) ?? "");
        }


        public static void ResponseOption(ResponseOption option, ReturnType returnType, bool returnComposedObjects)
        {
            Assert.AreEqual(returnType, option.ReturnType);
            Assert.AreEqual(returnComposedObjects, option.ReturnComposedObjects);
        }

        public static void Slot(Slot slot, string name, string type, IList<string> values)
        {
            Assert.AreEqual(name ?? "", slot.Name ?? "");
            Assert.AreEqual(type ?? "", slot.Type ?? "");

            Assert.AreEqual(values.Count, slot.Values.Count);
            for (var i = 0; i < values.Count; i++)
                Assert.AreEqual(values[i], slot.Values[i]);
        }

        public static void PostalAddress(PostalAddress address,
            string streetnumber, string street, string city, string state, string zip, string country)
        {
            Assert.AreEqual(streetnumber ?? "", address.StreetNumber ?? "");
            Assert.AreEqual(street ?? "", address.Street ?? "");
            Assert.AreEqual(state ?? "", address.StateOrProvince ?? "");
            Assert.AreEqual(city ?? "", address.City ?? "");
            Assert.AreEqual(zip ?? "", address.PostalCode ?? "");
            Assert.AreEqual(country ?? "", address.Country ?? "");
        }

        public static void Telephone(TelephoneNumber phone,
            string country, string area, string number, string extension, string type)
        {
            Assert.AreEqual(country ?? "", phone.CountryCode ?? "");
            Assert.AreEqual(area ?? "", phone.AreaCode ?? "");
            Assert.AreEqual(number ?? "", phone.Number ?? "");
            Assert.AreEqual(extension ?? "", phone.Extension ?? "");
            Assert.AreEqual(type ?? "", phone.PhoneType ?? "");
        }

        public static void Email(EmailAddress address,
            string email, string type)
        {
            Assert.AreEqual(email ?? "", address.Address ?? "");
            Assert.AreEqual(type ?? "", address.Type ?? "");
        }

        public static void Binding(ServiceBinding binding, string id, string name, string description, string uri, string serviceId)
        {
            Assert.AreEqual(id ?? "", binding.Id ?? "");
            Assert.AreEqual(name ?? "", binding.Name.GetValue() ?? "");
            Assert.AreEqual(name ?? "", binding.Name.GetValue("en-US") ?? "");
            Assert.AreEqual(description ?? "", binding.Description.GetValue() ?? "");
            Assert.AreEqual(description ?? "", binding.Description.GetValue("en-US") ?? "");
            Assert.AreEqual(uri, binding.AccessURI ?? "");
            Assert.AreEqual(serviceId, binding.Service ?? "");
        }

        public static void SpecificationLink(SpecificationLink link,
            string id, string binding, string specificationObject, string usageDescription, IList<string> parameters)
        {
            Assert.AreEqual(id ?? "", link.Id ?? "");
            Assert.AreEqual(binding ?? "", link.ServiceBinding ?? "");
            Assert.AreEqual(specificationObject ?? "", link.SpecificationObject ?? "");
            Assert.AreEqual(usageDescription ?? "", link.UsageDescription.GetValue() ?? "");
            Assert.AreEqual(usageDescription ?? "", link.UsageDescription.GetValue("en-US") ?? "");
            for (var i = 0; i < parameters.Count; i++)
                Assert.AreEqual(parameters[i], link.UsageParameters[i]);
        }
    }
}
