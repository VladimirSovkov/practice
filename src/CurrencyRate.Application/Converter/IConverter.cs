namespace CurrencyRate.Application.Converter
{
    public interface IConverter
    {
        decimal CalculateAmount(decimal fromRate, decimal toRate, decimal value);
    }
}
