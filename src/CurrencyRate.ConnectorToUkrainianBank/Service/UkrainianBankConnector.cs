using CurrencyRate.ConnectorToUkrainianBank.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Service;
using System;
using System.Collections.Generic;

namespace CurrencyRate.ConnectorToUkrainianBank.Service
{
    public class UkrainianBankConnector : IConnectorToUkrainianBank
    {
        private readonly string _url;
        private readonly UkrainianBankService ukrainianBankService = new UkrainianBankService();

        public UkrainianBankConnector(string url)
        {
            _url = url;
        }
    
        public List<UkrainianBankRates> LoadData(DateTime date)
        {
            if (date < new DateTime(2000, 01, 01) || date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException($"Incorrect date range for parsing data. date = {date.ToString()}");
            }
            string url = _url + "?date=" + date.ToString("yyyyMMdd") + "&json";
            return ukrainianBankService.GetData(url);
        }
    }
}
