using System;

namespace CurrencyRate.IntegrationTests.ObjectMothers
{
    public static class CurrencyRate
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
    }
}
