using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class CurrencyNameDto
    {
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
    }
}
