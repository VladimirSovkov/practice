using NUnit.Framework;
using System;
using CurrencyRate.WebsiteConnector.Service;
using CurrencyRate.WebsiteConnector.Interface;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System.Collections.Generic;
using FluentAssertions;

namespace CurrencyRate.WebsiteConnector.UnitTests
{
    public class ConnectorToKazakhstanBankTest
    {
        [Test]
        public void LoadDataFromKazakhstanBank()
        {
            IConnectorToKazakhstanBank connectorKzBank = new ConnectorToKazakhstanBank("..\\..\\..\\ObjectMother\\get_rates=");
            var expectedData = connectorKzBank.LoadData(new DateTime());
            var actualData = new List<KazakhstanBankModel>
            {
                new KazakhstanBankModel{ CurrencyId = "AUD", Date = new DateTime(2019, 03, 20), Name = "������������� ������", Rate = 267.13m },
                new KazakhstanBankModel{ CurrencyId = "AZN", Date = new DateTime(2019, 03, 20), Name = "��������������� �����", Rate = 222.33m },
                new KazakhstanBankModel{ CurrencyId = "AMD", Date = new DateTime(2019, 03, 20), Name = "��������� ����", Rate = 7.76m },
                new KazakhstanBankModel{ CurrencyId = "BYN", Date = new DateTime(2019, 03, 20), Name = "����������� �����", Rate = 178.91m },
                new KazakhstanBankModel{ CurrencyId = "BRL", Date = new DateTime(2019, 03, 20), Name = "����������� ����", Rate = 99.27m }
            };
            actualData.Should().BeEquivalentTo(expectedData);
        }
    }
}