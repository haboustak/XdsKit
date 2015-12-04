using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace XdsKit
{
    public static class Resource
    {
        public static string Get(string name)
        {
            using (Stream stream = Stream(Assembly.GetCallingAssembly(), name))
            {
                if (stream == null) throw new Exception(string.Format("The resource at path {0} was not found", name));

                using (var sr = new StreamReader(stream))
                    return sr.ReadToEnd();
            }
        }

        public static Stream Stream(string name)
        {
            return Stream(Assembly.GetCallingAssembly(), name);
        }

        private static Stream Stream(Assembly assembly, string name)
        {
            string resourceName =
                assembly.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith(name))
                ?? name;

            return assembly.GetManifestResourceStream(resourceName);
        }

        public static T Deserialize<T>(string name)
        {
            using (var stream = Stream(Assembly.GetCallingAssembly(), name))
            using (var reader = XmlReader.Create(stream))
            {
                XmlRootAttribute root = typeof(T).XmlRoot();
                var serializer = new XmlSerializer(typeof(T), root);
                return (T)serializer.Deserialize(reader);
            }            
        }
    }
}
