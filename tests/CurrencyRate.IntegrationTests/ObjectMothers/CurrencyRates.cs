using System;
using System.Collections.Generic;

namespace CurrencyRate.IntegrationTests.ObjectMothers
{
    public static class CurrencyRates
    {
        public class MotherObject
        {
            public decimal Rate;
            public string CurrencyId;
            public string Source;
            public DateTime Date;
        }

        public static readonly MotherObject Usd = new MotherObject
        {
            Rate = 73.41m,
            CurrencyId = "USD",
            Source = "index.minfin",
            Date = new DateTime(2020, 08, 14)
        };

        public static readonly List<CurrencyRate.Domain.CurrencyRateModel.CurrencyRate> currencyRateList = new List<CurrencyRate.Domain.CurrencyRateModel.CurrencyRate>
        {
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 73.5207m, CurrencyId = "USD", Date = new DateTime(2020, 08, 17), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 87.23m, CurrencyId = "EUR", Date = new DateTime(2020, 08, 17), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 1, CurrencyId = "RUB", Date = new DateTime(2020, 08, 17), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 72.5207m, CurrencyId = "USD", Date = new DateTime(2020, 08, 16), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 86.23m, CurrencyId = "EUR", Date = new DateTime(2020, 08, 16), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 1, CurrencyId = "RUB", Date = new DateTime(2020, 08, 16), Source = "https://ru.investing.com/currencies/usd-rub"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 73.2157m, CurrencyId = "USD", Date = new DateTime(2020, 08, 17), Source = "https://www.profinance.ru/currency_eur.asp"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 86.4092m, CurrencyId = "EUR", Date = new DateTime(2020, 08, 17), Source = "https://www.profinance.ru/currency_eur.asp"},
            new CurrencyRate.Domain.CurrencyRateModel.CurrencyRate { Rate = 1, CurrencyId = "RUB", Date = new DateTime(2020, 08, 17), Source = "https://www.profinance.ru/currency_eur.asp"}
        };    
    }
}
