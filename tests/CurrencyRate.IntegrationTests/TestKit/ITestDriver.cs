
using System;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.TestKit
{
    public interface ITestDriver : IDisposable
    {
        IServiceProvider Services();
        Task SeedDatabase();
    }
}
