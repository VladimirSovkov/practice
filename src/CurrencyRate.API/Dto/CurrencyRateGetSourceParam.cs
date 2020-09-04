using CurrencyRate.WebsiteConnector;
using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class CurrencyRateGetSourceParam
    {
        [DataMember(Name = "value")]
        public Source source { get; set; }
    }
}
