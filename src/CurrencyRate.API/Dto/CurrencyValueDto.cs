using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class CurrencyValueDto
    {
        [DataMember(Name = "value")]
        public decimal Value { get; set; }
    }
}
