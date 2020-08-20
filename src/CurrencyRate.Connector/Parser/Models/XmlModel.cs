using System;

namespace CurrencyRate.Connector.Models
{
    public class XmlModel
    {   
        public decimal Rate { get; set; }
        public string CurrencyId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
