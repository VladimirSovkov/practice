using CurrencyRate.IntegrationTests.TestKit;

namespace CurrencyRate.IntegrationTests
{
    public class AdminApiFeature : TestFeature
    {
        protected override void SetUp()
        {
            Driver = new TestDriver(typeof(AdminApiStartup));
            Runner = new TestRunner(Driver);
            Driver.SeedDatabase();
        }

        protected override void TearDown()
        {
        }
    }
}
