namespace CurrencyRate.Application.Converter
{
    public class Converter : IConverter
    {
        public decimal CalculateAmount(decimal rate, decimal value)
        {
            return rate * value;   
        }
    }
}
