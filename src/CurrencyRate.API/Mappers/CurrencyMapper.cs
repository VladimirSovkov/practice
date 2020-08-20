using CurrancyRate.Domain.CurrencyRateModel;
using CurrencyRate.Connector.Model;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class CurrencyMapper
    {
        public static Currency MapToCurrency(this ConnectorModel connectorModel)
        {
            return new Currency
            {
                CurrencyId = connectorModel.CurrencyId,
                Code = connectorModel.Code,
                Name = connectorModel.Name
            };
        }

        public static List<Currency> MapToCurrency(this IEnumerable<ConnectorModel> connectorModels)
        {
            return connectorModels == null ? new List<Currency>() : connectorModels.ToList().ConvertAll(MapToCurrency);
        }
    }
}
