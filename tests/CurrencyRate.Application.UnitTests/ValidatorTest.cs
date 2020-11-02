using CurrencyRate.Domain.RateConverter.Validation.Service;
using NUnit.Framework;
using System;

namespace CurrencyRate.Application.UnitTests
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test]
        public void CorrectSsumTest()
        {
            ValidationCheck validator = new ValidationCheck();
            Assert.True(validator.IsValueValid(0));
            Assert.True(validator.IsValueValid(1.12m));
            Assert.True(validator.IsValueValid(1200));
        }

        [Test]
        public void InvalidSumTest()
        {
            ValidationCheck validator = new ValidationCheck();
            Assert.False(validator.IsValueValid(-1));
            Assert.False(validator.IsValueValid(-1.123m));
        }

        [Test]
        public void CorrectCurrencyRateTest()
        {
            ValidationCheck validator = new ValidationCheck();
            Assert.True(validator.IsRateValid(1));
            Assert.True(validator.IsRateValid(1.123m));
        }

        [Test]
        public void TestWithIncorrectCurrencyRate()
        {
            ValidationCheck validator = new ValidationCheck();
            Assert.False(validator.IsRateValid(0));
            Assert.False(validator.IsRateValid(-1));
            Assert.False(validator.IsRateValid(-1.123m));
        }
    }
}
