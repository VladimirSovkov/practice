using CurrencyRate.API.Dto;
using CurrencyRate.IntegrationTests.TestKit;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.StepDefinitions
{
    public static class CurrencyRateSteps
    {
        public static async Task ThereHaveDatesApi(
            this ITestRunner testRunner, 
            List<DateTimeDto> expectedDto)
        {
            List<SourceNameDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<SourceNameDto>>($"v1/currencyRate");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }
    }
}
