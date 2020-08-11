using Microsoft.EntityFrameworkCore;
using CurrancyRate.Domain.CurrencyRateModel;

namespace CurrencyRate.Infrastructure.Data
{
    public class CurrencyRateContext : DbContext
    {
        public CurrencyRateContext(DbContextOptions<CurrencyRateContext> options) : base (options)
        { 
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrancyRate.Domain.CurrencyRateModel.CurrencyRate> CurrencyRate { get; set; }


    }
}
