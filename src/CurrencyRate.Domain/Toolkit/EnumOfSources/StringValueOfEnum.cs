using System;
using System.Reflection;

namespace CurrencyRate.Domain.Toolkit.EnumOfSources
{
    public static class StringValueOfEnum
    {
        static public string GetStringValue(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            StringValueAttribute attribute = fieldInfo.GetCustomAttribute(typeof(StringValueAttribute), false) as StringValueAttribute;
            return attribute.StringValue;
        }
    }
}
