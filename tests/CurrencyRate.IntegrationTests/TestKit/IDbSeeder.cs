using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.TestKit
{
    public interface IDbSeeder
    {
        Task Seed();
    }
}
