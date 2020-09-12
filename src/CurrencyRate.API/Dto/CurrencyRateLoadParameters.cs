using System;
using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class CurrencyRateLoadParameters
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }
    }
}
