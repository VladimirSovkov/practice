using CurrencyRate.WebsiteConnector.Interface;
using CurrencyRate.WebsiteConnector.Parse.Service;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Service
{
    public class ConnectorToKazakhstanBank : IConnectorToKazakhstanBank 
    {
        private readonly string _url;
        private readonly KazakhstanBankService kazakhstanBankService = new KazakhstanBankService();
        
        public ConnectorToKazakhstanBank(string url)
        {
            _url = url;
        }

        private string GetNumberToString(string number)
        {
            if (number.Length == 1)
            {
                number = "0" + number;
            }

            return number;
        }

        private string GetCorrectData(DateTime date)
        {
            string day = GetNumberToString(date.Day.ToString()) + ".";
            string month = GetNumberToString(date.Month.ToString()) + ".";
            string year = date.Year.ToString();
            return day + month + year;
        }

        public List<KazakhstanBankModel> LoadData(DateTime date)
        {
            string dateToStr = GetCorrectData(date);
            string url = _url + dateToStr;
            return kazakhstanBankService.GetData(url);
        }
    }
} 
