using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XdsKit.Oasis.Tests
{
    public static class AssemblyExtensions
    {
        public static Stream Resource(this Assembly assembly, string name)
        {
            return assembly.GetManifestResourceStream(typeof (AssemblyExtensions).Namespace + "." + name.TrimStart('.'));
        }
    }
}
