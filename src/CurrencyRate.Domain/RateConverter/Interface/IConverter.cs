namespace CurrencyRate.Application.RateConverter
{
    public interface IConverter
    {
        decimal Convert(decimal fromRate, decimal toRate, decimal value);
    }
}
