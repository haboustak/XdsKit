
using System.ComponentModel;

using System.Xml.Serialization;

namespace XdsKit.Oasis.RegRep.Services
{
    [XmlRoot(Namespace=Namespaces.Query)]
    public class ResponseOption
    {
        [XmlAttribute("returnType"), DefaultValue(ReturnType.RegistryObject)]
        public ReturnType ReturnType { get; set; }

        [XmlIgnore]
        public bool ReturnTypeSpecified
        {
            get { return ReturnType != ReturnType.RegistryObject; }
        }

        [XmlAttribute("returnComposedObjects"), DefaultValue(false)]
        public bool ReturnComposedObjects { get; set; }

        public ResponseOption()
        {
            ReturnType = ReturnType.RegistryObject;
        }
    }
}
