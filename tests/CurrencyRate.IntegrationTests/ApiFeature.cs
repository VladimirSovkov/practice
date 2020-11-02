using CurrencyRate.IntegrationTests.TestKit;

namespace CurrencyRate.IntegrationTests
{
    public class ApiFeature : TestFeature
    {
        protected override void SetUp()
        {
            Driver = new TestDriver(typeof(ApiStartup));
            Runner = new TestRunner(Driver);
            Driver.SeedDatabase();
        }

        protected override void TearDown()
        {
        }
    }
}
