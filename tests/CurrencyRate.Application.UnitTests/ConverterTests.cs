using CurrencyRate.Application.RateConverter;
using CurrencyRate.Domain.RateConverter.Validation.Service;
using NUnit.Framework;


namespace CurrencyRate.Application.UnitTests
{
    [TestFixture]
    public class CalculateAmountTests
    {
        [Test]
        public void TestWithCorrectPrimes()
        {
            var converter = new Converter(new ValidationCheck());
            var result = converter.Convert(74, 5, 2);
            Assert.That(result, Is.EqualTo(29.6m));
        }

        [Test]
        public void TestWithCorrectFractionalNumbers()
        {
            var converter = new Converter(new ValidationCheck());
            var result = converter.Convert(3.1m, 2.5m, 40.2m);
            Assert.That(result, Is.EqualTo(49.848m));
        }

        //дополнить тестами с ошибками 

        //public void WithZeroValue()
        //{
        //    var converter = new Converter.Converter();
        //    var result = converter.CalculateAmount(73.80m, 12, 0);
        //    Assert.That(result, Is.EqualTo(0));
        //}

        //public void ZeroRateAvailableCurrency()
        //{
        //    var converter = new Converter.Converter();
        //    var result = converter.CalculateAmount(0, 1, 1);
        //    Assert.That(result, Is.EqualTo(0));
        //}

        //public void ZeroRateDesiredCurrency()
        //{
        //    var converter = new Converter.Converter();
        //    var result = converter.CalculateAmount(1, 0, 1);
        //    Assert.That(result, Is.EqualTo(0));
        //}
    }
}
