using System;

namespace CurrencyRate.Connector.Model
{
    public class ConnectorModel
    {
        public string CurrencyId { get; set; }
        public int Code { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
    }
}
