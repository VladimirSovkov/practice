using System;
using System.Xml.Serialization;

namespace CurrencyRate.ConnectorToKazakhstanBank.Parse.Models
{
    [Serializable()]
    public class KazakhstanBankRates
    {
        [XmlElement("fullname")]
        public string Name { get; set; }
        
        [XmlElement("title")]
        public string CurrencyId { get; set; }
        
        [XmlElement("description")]
        public decimal Rate { get; set; }
 
        [XmlElement("quant")]
        public int Quant { get; set; }
        
        [XmlElement("index")]
        public string Index { get; set; }
        
        [XmlElement("change")]
        public string Change { get; set; }

        public string Date { get; set; }
    }
}
