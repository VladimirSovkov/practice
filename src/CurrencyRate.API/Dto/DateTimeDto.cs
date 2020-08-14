using System;
using System.Runtime.Serialization;

namespace CurrencyRate.API.Dto
{
    [DataContract]
    public class DateTimeDto
    {
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }
    }
}
