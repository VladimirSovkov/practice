using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class SourceNameDto
    {
        [DataMember(Name = "source")]
        public string Source { get; set; }
    }
}
