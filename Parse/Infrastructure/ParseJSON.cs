using Newtonsoft.Json;
using Parse.Domain.Interface;
using Parse.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Text;
//"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=20200718&json"

namespace Parse.Infrastructure
{
    public class ParseJSON : IParseJSON
    {
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
        public IEnumerable<JSONModel> GetData(string date)
        {
            string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=" + GetCorrectDateToString(date) + "&json";
            using (var webClient = new WebClient())
            {
                JSONModel DataRub = new JSONModel();
                var json_data = string.Empty;
                json_data = webClient.DownloadString(url);
                var curency = JsonConvert.DeserializeObject<List<JSONModel>>(json_data);
                foreach (JSONModel a in curency)
                {
                    if (a.cc == "RUB")
                    {
                        DataRub = a;
                        break;
                    }
                }

                foreach (JSONModel a in curency)
                {
                    a.Rate = a.Rate / DataRub.Rate;
                }
                return curency;
            }

        }
    }
}
