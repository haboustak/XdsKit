﻿using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit.Oasis.Tests
{
    public static class Resource
    {
        public static string Get(string name)
        {
            using (Stream stream = Stream(name))
            {
                if (stream == null) throw new Exception(string.Format("The resource at path {0} was not found", name));

                using (var sr = new StreamReader(stream))
                    return sr.ReadToEnd();
            }
        }

        public static Stream Stream(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(typeof(Resource).Namespace + "." + name.TrimStart('.'));
        }

        public static T Deserialize<T>(string name)
        {
            using (var stream = Stream(name))
            using (var reader = XmlReader.Create(stream))
            {
                XmlRootAttribute root = typeof(T).XmlRoot();
                var serializer = new XmlSerializer(typeof(T), root);
                return (T)serializer.Deserialize(reader);
            }            
        }
    }
}
