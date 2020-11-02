using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRate.Domain.CurrencyRateModel
{
    public interface ICurrencyRate
    {
        CurrencyRate GetCurrencyRate(DateTime date, string source);
        Task<List<string>> GetSource();
        IEnumerable<DateTime> GetAvailableSourceDates(string source);
        void AddArrayElements(List<CurrencyRate> arrayCurrencyRate);
        decimal GetСurrencyValue(string source, DateTime date, string currency);
        IEnumerable<string> GetSourceCurrencyList(string source);
        Task<bool> ThereIsSuchData(string source, DateTime date);
    }
}
