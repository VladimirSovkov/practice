using System;

namespace CurrencyRate.WebsiteConnector.Parse.WebsiteModels
{
    public class KazakhstanBankModel
    {
        public decimal Rate { get; set; }
        public string CurrencyId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
