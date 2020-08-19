using CurrancyRate.Domain.CurrencyRateModel;
using System.Collections.Generic;

namespace CurrencyRate.IntegrationTests.ObjectMothers
{
    public static class Currencies
    {
        public static readonly List<Currency> currencyList = new List<Currency>
        {
                new Currency { CurrencyId = "EUR", Code = 840, Name = "euro" },
                new Currency { CurrencyId = "USD", Code = 978, Name = "Dollar USA" },
                new Currency { CurrencyId = "RUB", Code = 810, Name = "Russian ruble" }
        };
    }
}
