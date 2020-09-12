using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using CurrencyRate.ConnectorToKazakhstanBank.Service;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.UnitTests.Parser
{
    [TestFixture]
    public class ParserKazakhstanBankcs
    {
        [Test]
        public void ParserOfKazakhstanBank()
        {
            KazakhstanBankService connectorKzBank = new KazakhstanBankService();
            var expectedData = connectorKzBank.GetData("Data\\ExcerptKazakhstanBank.xml");
            var actualData = new List<KazakhstanBankRates>
            {
                    new KazakhstanBankRates{ CurrencyId = "AUD", Date = "20.03.2019", Name = "АВСТРАЛИЙСКИЙ ДОЛЛАР", Rate = 267.13m, Change = "+0.05", Index = "DOWN", Quant = 1 },
                    new KazakhstanBankRates{ CurrencyId = "AZN", Date = "20.03.2019", Name = "АЗЕРБАЙДЖАНСКИЙ МАНАТ", Rate = 222.33m, Change = "+0.30", Index = "UP", Quant = 1},
                    new KazakhstanBankRates{ CurrencyId = "AMD", Date = "20.03.2019", Name = "АРМЯНСКИЙ ДРАМ", Rate = 7.76m, Change = "+0.01", Index = "UP", Quant = 10 },
                    new KazakhstanBankRates{ CurrencyId = "BYN", Date = "20.03.2019", Name = "БЕЛОРУССКИЙ РУБЛЬ", Rate = 178.91m, Change = "+0.94", Index = "UP", Quant = 1 },
                    new KazakhstanBankRates{ CurrencyId = "BRL", Date = "20.03.2019", Name = "БРАЗИЛЬСКИЙ РЕАЛ", Rate = 99.27m, Change = "+0.76", Index = "DOWN", Quant = 1 }
            };
            actualData.Should().BeEquivalentTo(expectedData);
        }
    }
}
