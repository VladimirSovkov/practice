using CurrencyRate.API.Dto;
using CurrencyRate.IntegrationTests.TestKit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.StepDefinitions
{
    public static class CurrencyRateSteps
    {
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
    }
}
