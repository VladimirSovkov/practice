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
            List<DateTimeDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<DateTimeDto>>($"v1/сurrencyRate/getDate");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }
    }
}
