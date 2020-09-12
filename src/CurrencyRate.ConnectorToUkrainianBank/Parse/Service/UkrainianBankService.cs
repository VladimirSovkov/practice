using CurrencyRate.ConnectorToUkrainianBank.Parse.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CurrencyRate.ConnectorToUkrainianBank.Parse.Service
{
    public class UkrainianBankService : IUkrainianBankServices
    {
        public List<UkrainianBankRates> GetData(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                string webSite = webClient.DownloadString(url);
                List<UkrainianBankRates> currencyRates = JsonConvert.DeserializeObject<List<UkrainianBankRates>>(webSite);
                return currencyRates;
            }
            catch(Exception exception)
            {
                throw new WebException(exception.Message);
            }
        }
    }
}