using System;
using System.Collections.Generic;
using System.Text;

namespace CurrancyRate.Domain.CurrencyRateModel
{
    public interface ICurrencyRate
    {
        CurrencyRate GetCurrencyRate(DateTime date, string source);
        IEnumerable<DateTime> GetAvailableSourceDates(string source);
        void AddArrayElements(List<CurrencyRate> arrayCurrencyRate);
        decimal GetСurrencyValue(string source, DateTime date, string currency);
        IEnumerable<string> GetSourceCurrencySpecificDate(string source, DateTime date);
    }
}
