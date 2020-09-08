using CurrencyRate.WebsiteConnector.Interface;
using System;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector
{
    public class WebsiteConnector : IWebsiteConnector
    {
        private readonly IConnectorToKazakhstanBank _connectorToKazakhstanBank;
        private readonly IConnectorToUkrainianBank _connectorToUkrainianBank;
        public WebsiteConnector(IConnectorToKazakhstanBank connectorToKazakhstanBank, IConnectorToUkrainianBank connectorToUkrainianBank)
        {
            _connectorToKazakhstanBank = connectorToKazakhstanBank;
            _connectorToUkrainianBank = connectorToUkrainianBank;
        }

        public List<string> GetSource()
        {
            return new List<string>
            {
                "Ukrainian bank",
                "National Bank KAZ"
            };
        }

        public IEnumerable<dynamic> GetData(Source source, DateTime date)
        {
            if (source == Source.NationalBankKaz)
            {
                return _connectorToKazakhstanBank.LoadData(date);
            }
            else if (source == Source.UkrainianBank)
            {
                return _connectorToUkrainianBank.LoadData(date);
            }
            return null;
        }
    }
}
