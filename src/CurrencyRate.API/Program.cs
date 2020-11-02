using CurrencyRate.Infrastructure.Startup;

namespace CurrencyRate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program<Startup>();

            program.Run(args);
        }
    }
}
