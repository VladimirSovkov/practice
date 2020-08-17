using CurrencyRate.API.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class CurrencyNameMapper
    {
        public static CurrencyNameDto Map(this string currency)
        {
            if (currency == null)
            {
                return null;
            }
            else
            {
                return new CurrencyNameDto { Currency = currency };
            }
        }

        //public static List<CurrencyNameDto> Map(this IEnumerable<string> currencyList)
        //{
        //    return currencyList == null ? new List<CurrencyNameDto>() : currencyList.ToList().ConvertAll(Map);
        //}
    }
}
