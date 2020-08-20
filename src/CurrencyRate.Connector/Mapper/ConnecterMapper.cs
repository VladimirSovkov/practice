using CurrencyRate.Connector.Model;
using CurrencyRate.Connector.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.Connector.Mapper
{
    public static class ConnecterMapper
    {
        public static ConnectorModel Map(this JsonModel jsonModel)
        {
            DateTime date;
            date = Convert.ToDateTime(jsonModel.exchangedate);
            return new ConnectorModel
            {
                CurrencyId = jsonModel.cc,
                Code = jsonModel.r030,
                Rate = jsonModel.Rate,
                Date = date,
                Name = jsonModel.txt,
                Source = "Ukrainian bank"
            };
        }

        public static List<ConnectorModel> Map(this IEnumerable<JsonModel> jsonModels)
        {
            return jsonModels == null ? new List<ConnectorModel>() : jsonModels.ToList().ConvertAll(Map);
        }

        public static ConnectorModel Map (this XmlModel xmlModel)
        {
            return new ConnectorModel
            {
                CurrencyId = xmlModel.CurrencyId,
                Code = 0,
                Rate = xmlModel.Rate,
                Date = xmlModel.Date,
                Name = xmlModel.Name,
                Source = "National Bank KAZ"
            };
        }

        public static List<ConnectorModel> Map(this IEnumerable<XmlModel> xmlModel)
        {
            return xmlModel == null ? new List<ConnectorModel>() : xmlModel.ToList().ConvertAll(Map);
        }
    }
}
