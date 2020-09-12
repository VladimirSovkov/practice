using CurrencyRate.Domain.RateConverter.Validation.Interface;

namespace CurrencyRate.Domain.RateConverter.Validation.Service
{
    public class ValidationCheck : IValidationCheck
    {
        public bool IsRateValid(decimal rate)
        {
            if (rate > 0 )
            {
                return true;
            }
            return false;
        }

        public bool IsValueValid(decimal value)
        {
            if (value >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
