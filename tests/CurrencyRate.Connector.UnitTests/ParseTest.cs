using NUnit.Framework;
using CurrencyRate.Connector.Repository;
using CurrencyRate.Connector.Model;
using CurrencyRate.Connector.Mapper;
using System.Linq;
using System.Collections.Generic;
using CurrencyRate.Connector.UnitTests.ObjectMother;
using FluentAssertions;

namespace CurrencyRate.Connector.UnitTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            JsonRepository jsonRepository = new JsonRepository();
            XmlRepository xmlRepository = new XmlRepository();
            List<ConnectorModel> expectedJsonObj = jsonRepository.GetData("..\\..\\..\\ObjectMother\\exchange.json").Map().ToList();
            var actualJsonObj = ConnectionObj.GetJsonObj;
            actualJsonObj.Should().BeEquivalentTo(expectedJsonObj);

            List<ConnectorModel> expectedXmlObj = xmlRepository.GetData("..\\..\\..\\ObjectMother\\get_rates.xml").Map().ToList();
            var actualXmlObj = ConnectionObj.GetXmlObj;
            actualJsonObj.Should().BeEquivalentTo(expectedJsonObj);
        }
    }
}