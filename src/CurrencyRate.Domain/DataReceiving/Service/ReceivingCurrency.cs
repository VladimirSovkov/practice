using CurrencyRate.ConnectorToKazakhstanBank.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Interface;
using CurrencyRate.Domain.CurrencyRateModel;
using CurrencyRate.Domain.DataRecipient.Adapter;
using CurrencyRate.Domain.DataRecipient.Interface;
using CurrencyRate.Domain.Toolkit.EnumOfSources;
using System;
using System.Collections.Generic;

namespace CurrencyRate.Domain.DataRecipient.Service
{
    public class ReceivingCurrency : IReceivingCurrency
    {
        private readonly IConnectorToKazakhstanBank _connectorToKazakhstanBank;
        private readonly IConnectorToUkrainianBank _connectorToUkrainianBank;

        public ReceivingCurrency(IConnectorToKazakhstanBank connectorToKazakhstanBank, IConnectorToUkrainianBank connectorToUkrainianBank)
        {
            _connectorToKazakhstanBank = connectorToKazakhstanBank;
            _connectorToUkrainianBank = connectorToUkrainianBank;
        }

        public List<string> GetSourcesList()
        {
            List<string> sourceList = new List<string>();
            foreach (Sources item in Enum.GetValues(typeof(Sources)))
            {
                sourceList.Add(item.GetStringValue());
            }
            return sourceList;
        }

        public List<Currency> GetCurrencies(string sources, DateTime date)
        {
            if (sources == Sources.NationalBankKaz.GetStringValue())
            {
                return _connectorToKazakhstanBank.LoadData(date).MapToCurrency();
            }
            else if (sources == Sources.UkrainianBank.GetStringValue())
            {
                return _connectorToUkrainianBank.LoadData(date).MapToCurrency();
            }
            else
            {
                throw new ArgumentException("Invalid source transferred");
            }
        }

        public List<CurrencyRateModel.CurrencyRate> GetCurrencyRates(string sources, DateTime date)
        {
            if (sources == Sources.NationalBankKaz.GetStringValue())
            {
                return _connectorToKazakhstanBank.LoadData(date).MapToCurrencyRate();
            }
            else if (sources == Sources.UkrainianBank.GetStringValue())
            {
                return _connectorToUkrainianBank.LoadData(date).MapToCurrencyRate();
            }
            else
            {
                throw new ArgumentException("Invalid source transferred");
            }
        }
    }
}
