using CurrencyRate.IntegrationTests.TestKit;
using System.Threading.Tasks;
using CurrencyRate.Infrastructure.Data;

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
            // TODO: Заполнение БД предустановленными данными, например списком валют
            
            
            await _context.SaveChangesAsync();
        }
    }
}
