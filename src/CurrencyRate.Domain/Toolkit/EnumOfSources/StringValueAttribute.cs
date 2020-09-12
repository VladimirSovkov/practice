using System;

namespace CurrencyRate.Domain.Toolkit.EnumOfSources
{
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
        public string StringValue { get; protected set; }
    }
}
