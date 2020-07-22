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
        public IEnumerable<JSONModel> GetData(string url)
        {
            //List<JSONModel> outData = new List<JSONModel> { new JSONModel { }  };
            using (var w = new WebClient())
            {
                JSONModel DataRub = new JSONModel();
                var json_data = string.Empty;
                json_data = w.DownloadString(url);
                //Console.WriteLine(json_data);
                var curency = JsonConvert.DeserializeObject<List<JSONModel>>(json_data);
                Console.WriteLine(Convert.ToString(curency[0].r030) + " " + curency[0].txt + " " + curency[0].Rate + " " + curency[0].cc + " " + curency[0].exchangedate);
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
                    Console.WriteLine(Convert.ToString(a.r030) + " " + a.txt + " " + a.Rate + " " + a.cc + " " + a.exchangedate);
                }
                return curency;
            }

        }
    }
}
