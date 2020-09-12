using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using CurrencyRate.Domain.CurrencyRateModel;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.Domain.DataRecipient.Adapter
{
    public static class CurrencyAdapter
    {
        public static Currency MapToCurrency(this KazakhstanBankRates kazakhstanRates)
        {
            if (kazakhstanRates == null)
            {
                return null;
            }
            else
            {
                return new Currency
                {
                    CurrencyId = kazakhstanRates.CurrencyId,
                    Code = 0,
                    Name = kazakhstanRates.Name
                };
            }
        }

        public static Currency MapToCurrency(this UkrainianBankRates ukrainianRates)
        {
            if (ukrainianRates == null)
            {
                return null;
            }
            else
            {
                return new Currency
                {
                    CurrencyId = ukrainianRates.CurrencyId,
                    Code = ukrainianRates.Code,
                    Name = ukrainianRates.Name
                };
            }
        }

        public static List<Currency> MapToCurrency(this IEnumerable<KazakhstanBankRates> kazakhstanRates)
        {
            return kazakhstanRates == null ? new List<Currency>() : kazakhstanRates.ToList().ConvertAll(MapToCurrency);
        }

        public static List<Currency> MapToCurrency(this IEnumerable<UkrainianBankRates> ukrainianRates)
        {
            return ukrainianRates == null ? new List<Currency>() : ukrainianRates.ToList().ConvertAll(MapToCurrency);
        }
    }
}
