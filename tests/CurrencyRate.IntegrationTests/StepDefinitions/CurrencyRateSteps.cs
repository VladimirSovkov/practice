using CurrencyRate.Domain.CurrencyRateModel;
using CurrencyRate.API.Dto;
using CurrencyRate.IntegrationTests.ObjectMothers;
using CurrencyRate.IntegrationTests.TestKit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.StepDefinitions
{
    public static class CurrencyRateSteps
    {
        public static void GivenICreateCurrencyList(
            this ITestRunner testRunner,
            List<Currency> currencies)
        {
            using (IServiceScope scope = testRunner.Driver.Services().CreateScope())
            {
                ICurrency currency = scope.ServiceProvider.GetService<ICurrency>();
                currency.AddDataOnSpecificDate(currencies);
            }
        }

        public static void GivenICreateCurrencyRateList(
            this ITestRunner testRunner,
            List<CurrencyRate.Domain.CurrencyRateModel.CurrencyRate> currencyRates
            )
        {
            using (IServiceScope scope = testRunner.Driver.Services().CreateScope())
            {
                ICurrencyRate currencyRate = scope.ServiceProvider.GetService<ICurrencyRate>();
                currencyRate.AddArrayElements(currencyRates);
            }
        }

        public static async Task ThenHaveSourceApi(
            this ITestRunner testRunner, 
            List<SourceNameDto> expectedDto)
        {
            List<SourceNameDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<SourceNameDto>>($"currencyRate/getSource");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }

        public static async Task ThenHaveDateApi(
            this ITestRunner testRunner,
            List<DateTimeDto> expectedDto)
        {
            List<DateTimeDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<DateTimeDto>>("currencyRate/getDate?source=https://ru.investing.com/currencies/usd-rub");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }

        public static async Task ThenHaveCurrencyApi(
            this ITestRunner testRunner,
            List<CurrencyNameDto> expectedDto)
        {
            List<CurrencyNameDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<CurrencyNameDto>>("currencyRate/GetListCurrencies?source=https://ru.investing.com/currencies/usd-rub&dateToString=16.08.2020");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }

        public static async Task ThenHaveValueApi(
            this ITestRunner testRunner,
            CurrencyValueDto expectedDto)
        {
            CurrencyValueDto actualDto = await testRunner.Driver.HttpClientGetAsync<CurrencyValueDto>("http://localhost:4401/currencyRate/GetCurrencyValue?source=https://ru.investing.com/currencies/usd-rub&dateToStr=17.08.2020&fromCurrency=RUB&toCurrency=EUR&value=174.46");
            actualDto.Should().BeEquivalentTo(expectedDto);
        }

        public static async Task ThenHaveLoadData(
            this ITestRunner testRunner)
        {
            var abc = new CurrencyRateLoadParameters { dateToStr = "date" };
            await testRunner.Driver.HttpClientPostAsync("http://localhost:4401/currencyRate/LoadData", abc);
        }
    }
}
