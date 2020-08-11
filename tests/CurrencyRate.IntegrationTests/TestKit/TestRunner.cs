namespace CurrencyRate.IntegrationTests.TestKit
{
    public class TestRunner : ITestRunner
    {
        public TestRunner(ITestDriver driver)
        {
            Driver = driver;
        }
        public ITestDriver Driver { get; }
    }
}
