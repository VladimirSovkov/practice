using CurrencyRate.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.API.Mappers
{
    public static class DateTimeMapper
    {
        public static DateTimeDto Map(this DateTime date)
        {
            if (date == null)
            {
                return null;
            }
            return new DateTimeDto
            {
                Date = date
            };
        }

        public static List<DateTimeDto> Map (this IEnumerable<DateTime> date)
        {
            return date == null ? new List<DateTimeDto>() : date.ToList().ConvertAll(Map); 
        }
    }
}
