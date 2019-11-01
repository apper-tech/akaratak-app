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
                    var value = parentProperty.GetValue(parent);

                    if (value != null &&
                          (value.IsStringAndNotEmpty()
                        || value.IsNumericTypeAndIsGreaterThanZero()
                        || value.IsNonPrimitive()))
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                    break;
                }
            }

            return child;
        }
        public static List<string> GetDataSourceTypes(this Enum source)
        {
            return Enum.GetNames(source.GetType()).ToList();
        }
        private static bool IsNumericTypeAndIsGreaterThanZero(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return Convert.ToDouble(o) > 0;
                default:
                    return false;
            }
        }

        private static bool IsStringAndNotEmpty(this object o)
        {
            return o is string i && string.IsNullOrEmpty(i);
        }

        private static bool IsNonPrimitive(this object o)
        {
            var t = o.GetType();
            return !(t.IsPrimitive
                     || t == typeof(Decimal)
                     || t == typeof(DateTime));
        }
    }
}
