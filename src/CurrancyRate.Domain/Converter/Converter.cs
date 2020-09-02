namespace CurrencyRate.Application.Converter
{
    public class Converter : IConverter
    {
        public decimal CalculateAmount(decimal fromRate, decimal toRate, decimal value)
        {
            if (toRate == 0)
            {
                return 0;
            }
            return (fromRate / toRate) * value;
        }
    }
}
