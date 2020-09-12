using CurrencyRate.ConnectorToUkrainianBank.Parse.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Service;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.UnitTests.Parser
{
    [TestFixture]
    public class ParserUkrainianBank
    {
        [Test]
        public void Test()
        {
            IUkrainianBankServices connectorUkBank = new UkrainianBankService();
            var expectedData = connectorUkBank.GetData("Data\\ExcerptUkrainianBank.json");
            var actualData = new List<UkrainianBankRates>
            {
                new UkrainianBankRates { CurrencyId = "AUD", Date = "20.03.2019", Code = 36, Rate = 19.29768m, Name = "Австралійський долар"},
                new UkrainianBankRates { CurrencyId = "CAD", Date = "20.03.2019", Code = 124, Rate = 20.484244m, Name = "Канадський долар"},
                new UkrainianBankRates { CurrencyId = "CNY", Date = "20.03.2019", Code = 156, Rate = 4.046496m, Name = "Юань Женьмiньбi"},
                new UkrainianBankRates { CurrencyId = "HRK", Date = "20.03.2019", Code = 191, Rate = 4.159377m, Name = "Куна"},
                new UkrainianBankRates { CurrencyId = "CZK", Date = "20.03.2019", Code = 203, Rate = 1.204861m, Name = "Чеська крона"},
            };
            actualData.Should().BeEquivalentTo(expectedData);

        }
    }
}
