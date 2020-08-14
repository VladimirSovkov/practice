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
            var result = converter.CalculateAmount(73.80m, 1);
            Assert.That(result, Is.EqualTo(73.80m));

            result = converter.CalculateAmount(73.80m, 1.25m);
            Assert.That(result, Is.EqualTo(92.25m));

            result = converter.CalculateAmount(73.80m, 0);
            Assert.That(result, Is.EqualTo(0));

            result = converter.CalculateAmount(0, 1);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
