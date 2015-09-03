using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace XdsKit
{
    public static partial class ObjectExtensions
    {
        public static bool DeepEquals(this object expected, object actual)
        {
            return DeepEquals(expected, actual, "this");
        }

        private static bool DeepEquals(this object expected, object actual, string path)
        {
            if (expected == null || actual == null) 
                return (expected == null && actual == null);

            var type = expected.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty).ToList();
            foreach (var property in properties)
            {
                var localPath = path +"."+ property.Name;
                var propertyInfo = type.GetProperty(property.Name);
                if (propertyInfo.GetIndexParameters().Any()) continue;

                var expectedItem = propertyInfo.GetValue(expected, null);
                var actualItem = propertyInfo.GetValue(actual, null);

                if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType.IsGenericType)
                {
                    var itExpected = expectedItem != null ? ((IEnumerable)expectedItem).GetEnumerator() : null;
                    var itActual = actualItem != null ? ((IEnumerable)actualItem).GetEnumerator() : null;
                    bool hasExpected;
                    var i = 0;
                    do
                    {
                        hasExpected = itExpected != null && itExpected.MoveNext();
                        if (hasExpected != (itActual!=null && itActual.MoveNext()))
                            throw new Exception(string.Format("Objects differ at: {0}", localPath+"["+i+"]"));

                        if (hasExpected && !itExpected.Current.DeepEquals(itActual.Current, localPath + "[" + i + "]"))
                            throw new Exception(string.Format("Objects differ at: {0}", localPath + "[" + i + "]"));
                        i++;
                    } while (hasExpected);
                }
                else if (typeof (string).IsAssignableFrom(propertyInfo.PropertyType)
                    && !string.Equals((string)expectedItem, (string)actualItem, StringComparison.OrdinalIgnoreCase))
                    throw new Exception(string.Format("Objects differ at: {0}", localPath));
                else if (!propertyInfo.PropertyType.IsValueType && !expectedItem.DeepEquals(actualItem, localPath))
                    throw new Exception(string.Format("Objects differ at: {0}", localPath));
                else if (propertyInfo.PropertyType.IsValueType && !expectedItem.Equals(actualItem))
                    throw new Exception(string.Format("Objects differ at: {0}", localPath)); 
            }
            return true;
        }
    }
}
