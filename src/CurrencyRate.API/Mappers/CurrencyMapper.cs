using CurrancyRate.Domain.CurrencyRateModel;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class CurrencyMapper
    {
        public static Currency MapToCurrency(this UkrainianBankModel ukrainianBankModel)
        {
            return new Currency
            {
                CurrencyId = ukrainianBankModel.cc,
                Code = ukrainianBankModel.r030,
                Name = ukrainianBankModel.txt
            };
        }

        public static Currency MapToCurrency(this KazakhstanBankModel kazakhstanBankModel)
        {
            return new Currency
            {
                CurrencyId = kazakhstanBankModel.CurrencyId,
                Code = 0,
                Name = kazakhstanBankModel.Name
            };
        }

        public static List<Currency> MapToCurrency(this IEnumerable<UkrainianBankModel> ukrainianBankModels)
        {
            return ukrainianBankModels == null ? new List<Currency>() : ukrainianBankModels.ToList().ConvertAll(MapToCurrency);
        }

        public static List<Currency> MapToCurrency(this IEnumerable<KazakhstanBankModel> kazakhstanBankModels)
        {
            return kazakhstanBankModels == null ? new List<Currency>() : kazakhstanBankModels.ToList().ConvertAll(MapToCurrency);
        }
    }
}
