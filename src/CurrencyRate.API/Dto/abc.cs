using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class abc
    {
        [DataMember(Name = "dateToStr")]
        public string dateToStr { get; set; }
    }
}
