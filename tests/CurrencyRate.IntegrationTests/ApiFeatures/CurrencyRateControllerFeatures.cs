using CurrencyRate.IntegrationTests.StepDefinitions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyRate.IntegrationTests.ObjectMothers;
using System;
using System.Linq;
using CurrencyRate.API.Mappers;

namespace CurrencyRate.IntegrationTests.AdminApiFeatures
{
    public class CurrencyRateControllerFeatures : ApiFeature
    {
        [Test]
        public async Task GetUsers_Scenario()
        {
            //Given
            Runner.GivenICreateCurrencyList(Currencies.currencyList);
            Runner.GivenICreateCurrencyRateList(CurrencyRates.currencyRateList);

            //When

            //Then
            List<string> sourceNameList = new List<string> { "Ukrainian bank", "National Bank KAZ" };
            await Runner.ThenHaveSourceApi(sourceNameList.MapToSourceName());

            List<string> currencyNameList = CurrencyRates.currencyRateList
                                                .Select(currencyRate => currencyRate.CurrencyId)
                                                .Distinct()
                                                .ToList();
            await Runner.ThenHaveCurrencyApi(currencyNameList.MapToCurrencyName());

            //CurrencyValueDto currencyNameDto = new CurrencyValueDto { Value = 174.46m/87.23m };
            //await Runner.ThenHaveValueApi(currencyNameDto);

            //await Runner.ThenHaveLoadData();
        }
    }
}
