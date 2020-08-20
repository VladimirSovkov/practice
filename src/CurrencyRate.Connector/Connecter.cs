using CurrencyRate.Connector.Model;
using CurrencyRate.Connector.Mapper;
using CurrencyRate.Connector.Models;
using CurrencyRate.Connector.Parser.Models;
using CurrencyRate.Connector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.Connector
{
    public class Connecter : IConnector
    {

        private readonly XmlRepository xmlRepository = new XmlRepository();
        private readonly JsonRepository jsonRepository = new JsonRepository(); 

        public List<ConnectorModel> Load(DateTime date, Source source)
        {
            if (source == Source.NationalBankKaz)
            {
                string dateToStr = CorrectDataToStrMaper.GetCorrectDataToXml(date);
                string url = "https://www.nationalbank.kz/rss/get_rates.cfm?fdate=" + dateToStr;
                List<XmlModel> dataList = xmlRepository.GetData(url).ToList();
                return dataList.Map();
            }
            else if(source == Source.UkrainianBank)
            {
                string dateToStr = CorrectDataToStrMaper.GetCorrectDataToJson(date);
                string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=" + dateToStr + "&json";
                List<JsonModel> dataList = jsonRepository.GetData(url).ToList();
                return dataList.Map();
            }

            return new List<ConnectorModel>();
        }
    }
}
