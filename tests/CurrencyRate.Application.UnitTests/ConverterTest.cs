using NUnit.Framework;
using CurrencyRate.Application.Converter;

namespace CurrencyRate.Application.UnitTests
{
    [TestFixture]
    public class CalculateAmountTest
    {
        [Test]
        public void WithPrimesNumbers()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(74, 5, 2);
            Assert.That(result, Is.EqualTo(29.6m));
        }

        public void WithFractionalNumbers()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(2, 80, 40.2m);
            Assert.That(result, Is.EqualTo(1.005m));
        }

        public void WithZeroValue()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(73.80m, 12, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        public void ZeroRateAvailableCurrency()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(0, 1, 1);
            Assert.That(result, Is.EqualTo(0));
        }

        public void ZeroRateDesiredCurrency()
        {
            var converter = new Converter.Converter();
            var result = converter.CalculateAmount(1, 0, 1);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
