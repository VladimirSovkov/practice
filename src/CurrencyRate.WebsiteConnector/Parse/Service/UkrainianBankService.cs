using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace CurrencyRate.WebsiteConnector.Parse.Service
{
    public class UkrainianBankService : IUkrainianBankServices
    {
        public List<UkrainianBankModel> GetData(string url)
        {
            using (var webClient = new WebClient())
            {
                var json_data = string.Empty;
                json_data = webClient.DownloadString(url);
                var curency = JsonConvert.DeserializeObject<List<UkrainianBankModel>>(json_data);
                return curency;
            }
        }
    }
}
