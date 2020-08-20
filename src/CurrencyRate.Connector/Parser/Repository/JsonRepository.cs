using CurrencyRate.Connector.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using CurrencyRate.Connector.Interface;

namespace CurrencyRate.Connector.Repository 
{
    public class JsonRepository : IJsonRepository
    {
        public JsonRepository()
        {
        }

        public IEnumerable<JsonModel> GetData(string url)
        {
            using (var webClient = new WebClient())
            {
                var json_data = string.Empty;
                json_data = webClient.DownloadString(url);
                var curency = JsonConvert.DeserializeObject<List<JsonModel>>(json_data);
                return curency;
            }

        }
    }
}
