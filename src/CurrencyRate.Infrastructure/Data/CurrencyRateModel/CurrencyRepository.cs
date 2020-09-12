using CurrencyRate.Domain.CurrencyRateModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.Infrastructure.Data.CurrencyRateModel
{
    public class CurrencyRepository : ICurrency
    {
        private readonly CurrencyRateContext _DbContext;

        public CurrencyRepository(CurrencyRateContext appDbContext)
        {
            _DbContext = appDbContext;
        }
        public void AddElement(Currency currency)
        {
            _DbContext.Currency.AddRange(currency);
            _DbContext.SaveChanges();
        }
        public void AddDataOnSpecificDate(List<Currency> arrayCurrency)
        {
            var currencyList = _DbContext.Currency;
            foreach (var item in arrayCurrency)
            {
                if (!currencyList.Contains(item))
                {
                    _DbContext.Add(item);
                }
            }
            _DbContext.SaveChanges();
        }
    }
}
