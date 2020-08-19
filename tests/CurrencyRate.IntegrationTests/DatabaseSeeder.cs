using CurrencyRate.IntegrationTests.TestKit;
using System.Threading.Tasks;
using CurrencyRate.Infrastructure.Data;
using CurrencyRate.IntegrationTests.ObjectMothers;

namespace CurrencyRate.IntegrationTests
{
    public class DatabaseSeeder : IDbSeeder
    {
        private readonly CurrencyRateContext _context;

        public DatabaseSeeder( CurrencyRateContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            //Заполнение БД предустановленными данными
            _context.Currency.AddRange(Currencies.currencyList);
            _context.SaveChanges();

            _context.CurrencyRate.AddRange(CurrencyRates.currencyRateList);
            await _context.SaveChangesAsync();
        }
    }
}
