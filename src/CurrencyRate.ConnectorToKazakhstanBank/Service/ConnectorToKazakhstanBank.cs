using CurrencyRate.ConnectorToKazakhstanBank.Interface;
using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using System;
using System.Collections.Generic;

namespace CurrencyRate.ConnectorToKazakhstanBank.Service
{
    public class KazakhstanBankConnector : IConnectorToKazakhstanBank 
    {
        private readonly string _url;
        private readonly KazakhstanBankService kazakhstanBankService = new KazakhstanBankService();
        
        public KazakhstanBankConnector(string url)
        {
            _url = url;
        }

        public List<KazakhstanBankRates> LoadData(DateTime date)
        {
            if (date < new DateTime(2000, 01, 01) || date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException($"Incorrect date range for parsing data. date = {date.ToString()}");
            }
            string url = _url + "?fdate=" + date.ToString("dd.MM.yyyy");
            return kazakhstanBankService.GetData(url);
        }
    }
} 
