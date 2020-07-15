using System;
using System.Data.Entity;

namespace DBTest
{
    public class MyDB : DbContext
    {
        public MyDB() : base("DBTest.Properties.Settings.CurrencyRateConnectionString")
        {

        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }


    }
}
