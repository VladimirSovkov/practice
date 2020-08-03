using DataBase.Domain.Model;
using System;
using System.Collections.Generic;

namespace DataBase.Domain.Interface
{
    interface ICurrencyRateRepository
    {
        CurrencyRate GetCurrencyRate(DateTime date, string source);
        IEnumerable<DateTime> GetAvailableSourceDates(string source);
        void AddArrayElements(List<CurrencyRate> arrayCurrencyRate);
        decimal GetСurrencyValue(string source, DateTime date, string currency);
        IEnumerable<string> GetSourceCurrencySpecificDate(string source, DateTime date);

    }
}
