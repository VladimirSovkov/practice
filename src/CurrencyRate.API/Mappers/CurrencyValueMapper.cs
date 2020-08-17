using CurrencyRate.API.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class CurrencyValueMapper
    {
        public static CurrencyValueDto Map(this decimal value)
        {
            return new CurrencyValueDto { Value = value };
        }

        public static List<CurrencyValueDto> Map(this IEnumerable<decimal> valueList)
        {
            return valueList == null ? new List<CurrencyValueDto>() : valueList.ToList().ConvertAll(Map);
        }
    }
}
