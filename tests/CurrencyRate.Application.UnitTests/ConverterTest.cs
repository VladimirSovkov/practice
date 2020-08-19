using NUnit.Framework;
using CurrencyRate.Application.Converter;

namespace CurrencyRate.Application.UnitTests
{
    [TestFixture]
    public class ConverterTest
    {
        [Test]
        public void CalculateAmountTest()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(74, 5, 2);
            Assert.That(result, Is.EqualTo(29.6m));

            result = converter.CalculateAmount(2, 80, 40.2m);
            Assert.That(result, Is.EqualTo(1.005m));

            result = converter.CalculateAmount(73.80m, 12, 0);
            Assert.That(result, Is.EqualTo(0));

            result = converter.CalculateAmount(0, 1, 1);
            Assert.That(result, Is.EqualTo(0));

            result = converter.CalculateAmount(1, 0, 1);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
