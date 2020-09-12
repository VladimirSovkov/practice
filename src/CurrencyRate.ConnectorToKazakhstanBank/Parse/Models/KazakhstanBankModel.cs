using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyRate.ConnectorToKazakhstanBank.Parse.Models
{
    [Serializable()]
    [XmlRoot("rates", Namespace = "", IsNullable = false)]
    public class KazakhstanBankModel
    {
        [XmlElement("generator")]
        public string Generator { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("copyright")]
        public string Copyright { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }
        
        [XmlElement("item")]
        public List<KazakhstanBankRates> CurrenciesList { get; set; }

    }
}
