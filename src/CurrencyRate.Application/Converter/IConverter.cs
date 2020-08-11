namespace CurrencyRate.Application.Converter
{
    interface IConverter
    {
        decimal CalculateAmount(decimal rate, decimal value);
    }
}
