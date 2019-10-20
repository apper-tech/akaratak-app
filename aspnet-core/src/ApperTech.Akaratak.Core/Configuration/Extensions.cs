using System;
using System.Collections.Generic;
using System.Linq;
using ApperTech.Akaratak.Realestate;

namespace ApperTech.Akaratak.Configuration
{
    public static class Extensions
    {
        public static object Copy(this object child, object parent)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name != childProperty.Name ||
                        parentProperty.PropertyType != childProperty.PropertyType || !childProperty.CanWrite) continue;
                    if ((parentProperty.GetValue(parent) is string s && !string.IsNullOrEmpty(s))
                        || (parentProperty.GetValue(parent) is int i && i > 0))
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                    break;
                }
            }

            return child;
        }

    }
}
