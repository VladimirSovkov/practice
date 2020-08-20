using CurrancyRate.Domain.CurrencyRateModel;
using CurrencyRate.Connector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRate.API.Mappers
{
    public static class CurrencyRateMapper
    {
        public static CurrancyRate.Domain.CurrencyRateModel.CurrencyRate MapToCurrencyRate(this ConnectorModel connectorModel)
        {
            return new CurrancyRate.Domain.CurrencyRateModel.CurrencyRate
            {
                Rate = connectorModel.Rate,
                CurrencyId = connectorModel.CurrencyId,
                Source = connectorModel.Source,
                Date = connectorModel.Date
            };
        }
         public static List<CurrancyRate.Domain.CurrencyRateModel.CurrencyRate> MapToCurrencyRate(this List<ConnectorModel> connectorModels )
        {
            return connectorModels == null ? new List<CurrancyRate.Domain.CurrencyRateModel.CurrencyRate>() : connectorModels.ToList().ConvertAll(MapToCurrencyRate);
        }
    }
}
