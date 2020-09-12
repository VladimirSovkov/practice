using System;
using System.Runtime.Serialization;

namespace CurrencyRate.ConnectorToUkrainianBank.Parse.Models
{
    [DataContract]
    public class UkrainianBankRates
    {
        [DataMember(Name = "r030")]
        public int Code { get; set; }

        [DataMember(Name = "txt")]
        public string Name { get; set; }

        [DataMember(Name = "rate")]
        public decimal Rate { get; set; }

        [DataMember(Name = "cc")]
        public string CurrencyId { get; set; }

        [DataMember(Name = "exchangedate")]
        public string Date { get; set; }
    }
}
