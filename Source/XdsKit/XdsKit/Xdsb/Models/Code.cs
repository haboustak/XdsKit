using System.Collections.Generic;
using XdsKit.Oasis.RegRep;
using XdsKit.Oasis.RegRep.Models;

namespace XdsKit.Xdsb.Models
{
    public abstract class Code
    {
        protected XdsClassification Scheme { get; set; }

        public string UniqueId { get; set; }

        public string CodeSystemId { get; set; }

        public string Value { get; set; }
        
        public string DisplayName { get; set; }

        public virtual Classification ToClassification(string parent)
        {
            var attribute = new Classification
            {
                ClassificationScheme = Scheme,
                ClassifiedObject = parent,
                ObjectType = ObjectType.Classification,
                NodeRepresentation = Value,
                Name = XmlUtil.LocalString(DisplayName)
            };
            if (!string.IsNullOrEmpty(CodeSystemId))
            {
                attribute.Slots.Add(new Slot
                {
                    Name = "codingScheme",
                    Values = new List<string>
                    {
                        CodeSystemId
                    }
                });
            }

            return attribute;
        }
    }
}
