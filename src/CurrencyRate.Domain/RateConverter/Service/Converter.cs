using CurrencyRate.Domain.RateConverter.Validation.Interface;
using System;

namespace CurrencyRate.Application.RateConverter
{
    public class Converter : IConverter
    {
        private readonly IValidationCheck validationCheck;

        public Converter(IValidationCheck validationCheck)
        {
            this.validationCheck = validationCheck;
        }

        public decimal Convert( decimal fromRate, decimal toRate, decimal value)
        {
            if (validationCheck.IsRateValid(fromRate) && validationCheck.IsRateValid(toRate))
            {
                if (validationCheck.IsValueValid(value))
                {
                    return (fromRate / toRate) * value;
                }
                throw new ArgumentOutOfRangeException("the value cannot be less than zero");
            }
            throw new ArgumentOutOfRangeException("the course cannot be negative and is equal to zero");
        }
    }
}
