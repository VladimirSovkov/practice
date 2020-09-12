using System;
using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class ParametersForGetTotalValue
    {
        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "fromCurrency")]
        public string FromCurrency { get; set; }

        [DataMember(Name = "toCurrency")]
        public string ToCurrency { get; set; }
        
        [DataMember(Name = "value")]
        public decimal Value { get; set; }

    }
}
