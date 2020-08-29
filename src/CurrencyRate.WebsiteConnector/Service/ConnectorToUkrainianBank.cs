using CurrencyRate.WebsiteConnector.Interface;
using CurrencyRate.WebsiteConnector.Parse.Service;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Service
{
    public class ConnectorToUkrainianBank : IConnectorToUkrainianBank
    {
        private readonly string _url;
        private readonly UkrainianBankService ukrainianBankService = new UkrainianBankService();

        public ConnectorToUkrainianBank(string url)
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
            string year = date.Year.ToString();
            string month = GetNumberToString(date.Month.ToString());
            string day = GetNumberToString(date.Day.ToString());
            return year + month + day;
        }
    
        public List<UkrainianBankModel> LoadData(DateTime date)
        {
            string dateToStr = GetCorrectData(date);
            string url = _url + dateToStr + "&json";
            return ukrainianBankService.GetData(url);
        }
    }
}
