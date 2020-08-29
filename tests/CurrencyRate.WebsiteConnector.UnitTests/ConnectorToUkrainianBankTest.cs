using NUnit.Framework;
using System;
using CurrencyRate.WebsiteConnector.Service;
using CurrencyRate.WebsiteConnector.Interface;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System.Collections.Generic;
using FluentAssertions;

namespace CurrencyRate.WebsiteConnector.UnitTests
{
    public class ConnectorToUkrainianBankTest
    {
        [Test]
        public void LoadDataFromUkrainianBank()
        {
            IConnectorToUkrainianBank connectorUkBank = new ConnectorToUkrainianBank("..\\..\\..\\ObjectMother\\exchange=");
            var expectedData = connectorUkBank.LoadData(new DateTime());
            var actualData = new List<UkrainianBankModel>
            {
                new UkrainianBankModel { cc = "AUD", exchangedate = "20.03.2019", r030 = 36, Rate = 19.29768m, txt = "Австралійський долар"},
                new UkrainianBankModel { cc = "CAD", exchangedate = "20.03.2019", r030 = 124, Rate = 20.484244m, txt = "Канадський долар"},
                new UkrainianBankModel { cc = "CNY", exchangedate = "20.03.2019", r030 = 156, Rate = 4.046496m, txt = "Юань Женьмiньбi"},
                new UkrainianBankModel { cc = "HRK", exchangedate = "20.03.2019", r030 = 191, Rate = 4.159377m, txt = "Куна"},
                new UkrainianBankModel { cc = "CZK", exchangedate = "20.03.2019", r030 = 203, Rate = 1.204861m, txt = "Чеська крона"},
            };
            actualData.Should().BeEquivalentTo(expectedData);
        }
    }
}
