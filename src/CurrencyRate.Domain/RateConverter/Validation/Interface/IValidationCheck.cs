namespace CurrencyRate.Domain.RateConverter.Validation.Interface
{
    public interface IValidationCheck
    {
        bool IsRateValid(decimal rate);
        bool IsValueValid(decimal value);
    }
}
