using Microsoft.EntityFrameworkCore;
using CurrencyRate.Domain.CurrencyRateModel;

namespace CurrencyRate.Infrastructure.Data
{
    public class CurrencyRateContext : DbContext
    {
        public CurrencyRateContext(DbContextOptions<CurrencyRateContext> options) : base (options)
        { 
        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyRate.Domain.CurrencyRateModel.CurrencyRate> CurrencyRate { get; set; }
    }
}
