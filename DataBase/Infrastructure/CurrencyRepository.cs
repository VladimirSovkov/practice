using DataBase.Domain.Interface;
using DataBase.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Parse.Domain.Model;
using Parse.Domain.Interface;
using Parse.Infrastructure;

namespace DataBase.Infrastructure
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AppDBContext _appDbContext;

        public CurrencyRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddElement(Currency currency)
        {
            _appDbContext.Currency.AddRange(currency);
            _appDbContext.SaveChanges();
        }
        public void AddDataOnSpecificDate(List<Currency> arrayCurrency)
        {
            var currencyList = _appDbContext.Currency;
            foreach (var item in arrayCurrency)
            {
                if (!currencyList.Contains(item))
                {
                    _appDbContext.Add(item);
                }
            }
            _appDbContext.SaveChanges();
        }
    }
}
