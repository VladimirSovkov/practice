using CurrencyRate.Connector.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using CurrencyRate.Connector.Interface;

namespace CurrencyRate.Connector.Repository 
{
    class JsonRepository : IJsonRepository
    {
        private readonly string _date;

        private string GetCorrectNumberToString(string number)
        {
            if (number.Length == 1)
            {
                number = "0" + number;
            }

            return number;
        }

        private string GetCorrectDateToString(string date)
        {
            //try
            //{
            DateTime dateTime = Convert.ToDateTime(date);
            string year = dateTime.Year.ToString();
            string month = GetCorrectNumberToString(dateTime.Month.ToString());
            string day = GetCorrectNumberToString(dateTime.Day.ToString());
            date = year + month + day;
            //}
            //catch (Exception)
            //{
            //    throw new ArgumentException("incorrect");
            //}

            return date;
        }

        public JsonRepository(string date)
        {
            _date = GetCorrectDateToString(date);
        }

        public IEnumerable<JsonModel> GetData()
        {
            string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=" + _date + "&json";
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
