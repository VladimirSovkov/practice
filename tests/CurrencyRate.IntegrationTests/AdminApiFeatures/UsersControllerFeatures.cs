using CurrencyRate.API.Dto;
using CurrencyRate.IntegrationTests.StepDefinitions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.AdminApiFeatures
{
    public class UsersControllerFeatures : AdminApiFeature
    {
        [Test]
        public async Task GetUsers_Scenario()
        {
            //Given 
            //When
            //Then
            await Runner.ThereHaveDatesApi(new List<DateTimeDto>());
        }
    }
}
