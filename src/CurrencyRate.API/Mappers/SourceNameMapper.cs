using CurrencyRate.API.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class SourceNameMapper
    {
        public static SourceNameDto Map(this string source)
        {
            if ( source == null)
            {
                return null;
            }
            else
            {
                return new SourceNameDto { Source = source };
            }
        }

        public static List<SourceNameDto> MapToSourceName(this IEnumerable<string> sourceList)
        {
            return sourceList == null ? new List<SourceNameDto>() : sourceList.ToList().ConvertAll(Map);
        }
    }
}
