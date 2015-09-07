using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace XdsKit.Hl7
{
    public class DataType
    {
        public IList<PropertyInfo> Components { get; protected set; }

        public DataType()
        {
            var t = typeof (DataType);
            Components = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => t.IsAssignableFrom(p.PropertyType)).ToList();
        }

        public override string ToString()
        {
            return Encode();
        }

        public static T Parse<T>(T field, string values)
            where T: DataType
        {
            if (field == null) field = Activator.CreateInstance<T>();
            if (!string.IsNullOrEmpty(values)) field.SetValues(values.Split('^'));
            return field;
        }

        public virtual void SetValues(string[] values)
        {
            if (!Components.Any()) SetValue(values[0]);

            int len = Math.Min(values.Length, Components.Count);
            for (var i = 0; i < len; i++)
            {
                if (string.IsNullOrEmpty(values[i])) continue;

                var component = Components[i].GetValue(this) as DataType;
                if (component == null)
                {
                    component = (DataType)Activator.CreateInstance(Components[i].PropertyType);
                    Components[i].SetValue(this, component);
                }
                if (!component.Components.Any()) component.SetValue(values[i]);
                else
                {
                    var subcomponents = values[i].Split('&');
                    int subLen = Math.Min(subcomponents.Length, component.Components.Count);
                    for (var j = 0; j < subLen; j++)
                    {
                        var subcomponent = component.Components[j].GetValue(component) as DataType;
                        if (subcomponent == null)
                        {
                            subcomponent = (DataType)Activator.CreateInstance(component.Components[j].PropertyType);
                            component.Components[j].SetValue(component, subcomponent);
                        }
                        subcomponent.SetValue(subcomponents[j]);
                    }
                }
            }
        }

        public virtual string Encode()
        {
            var result = new StringBuilder();

            if (!Components.Any()) result.Append(GetValue());
            foreach (PropertyInfo prop in Components)
            {
                var component = prop.GetValue(this) as DataType;
                if (component == null)
                {
                    result.Append("^");
                    continue;
                }

                if (!component.Components.Any()) result.Append(component.GetValue());
                foreach (PropertyInfo subProp in component.Components)
                {
                    var subcomponent = subProp.GetValue(component) as DataType;
                    if (subcomponent!=null) result.Append(subcomponent.GetValue());
                    result.Append("&");
                }
                while (result.Length>0 && result[result.Length-1] == '&') result.Length--;
                result.Append("^");
            }
            while (result.Length > 0 && result[result.Length - 1] == '^') result.Length--;
            return result.ToString();
        }

        public virtual string GetValue()
        {
            var component = (DataType)Components[0].GetValue(this);
            return component!=null ? component.GetValue() : null;
        }

        public virtual void SetValue(string value)
        {
            var component = (DataType) Components[0].GetValue(this);
            if (component == null)
            {
                component = (DataType)Activator.CreateInstance(Components[0].PropertyType);
                Components[0].SetValue(this, component);
            }
            if (value == "\"\"") value = "";
            component.SetValue(value);
        }
    }
}
