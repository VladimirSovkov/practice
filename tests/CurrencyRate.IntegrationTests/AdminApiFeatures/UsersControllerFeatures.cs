using CurrencyRate.IntegrationTests.StepDefinitions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyRate.IntegrationTests.ObjectMothers;
using System;
using System.Linq;
using CurrencyRate.API.Mappers;
using CurrencyRate.API.Dto;

namespace CurrencyRate.IntegrationTests.AdminApiFeatures
{
    public class UsersControllerFeatures : AdminApiFeature
    {
        [Test]
        public async Task GetUsers_Scenario()
        {
            //Given
            Runner.GivenICreateCurrencyList(Currencies.currencyList);
            Runner.GivenICreateCurrencyRateList(CurrencyRates.currencyRateList);

            //When

            //Then
            List<string> sourceNameList = CurrencyRates.currencyRateList
                                            .Select(currencyRate => currencyRate.Source)
                                            .Distinct()
                                            .ToList();
            await Runner.ThenHaveSourceApi(sourceNameList.MapToSourceName());

            List<DateTime> dateTimeList = CurrencyRates.currencyRateList
                                            .Select(currencyRate => currencyRate.Date)
                                            .Distinct()
                                            .ToList();
            await Runner.ThenHaveDateApi(dateTimeList.Map());

            List<string> currencyNameList = CurrencyRates.currencyRateList
                                                .Select(currencyRate => currencyRate.CurrencyId)
                                                .Distinct()
                                                .ToList();
            await Runner.ThenHaveCurrencyApi(currencyNameList.MapToCurrencyName());

            CurrencyValueDto currencyNameDto = new CurrencyValueDto { Value = 174.46m/87.23m };
            await Runner.ThenHaveValueApi(currencyNameDto);

            await Runner.ThenHaveLoadData();
        }
    }
}
