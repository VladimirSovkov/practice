using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class CurrencyRateLoadParameters
    {
        [DataMember(Name = "dateToStr")]
        public string dateToStr { get; set; }

        [DataMember(Name = "source")]
        public string source { get; set; }
    }
}
