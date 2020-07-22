using CurrencyRate.Domain.Interface;
using CurrencyRate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRate.Domain.Mock
{
    public class CurrencyMock : ICurrency
    {
        public IEnumerable<Currency> GetAllCurrency()
        {
            return new List<Currency> { new Currency { } };
        }
    }
}
