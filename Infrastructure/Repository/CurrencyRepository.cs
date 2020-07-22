using Infrastructure.Interface;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class CurrencyRepository : ICurrency
    {
        private readonly AppDBContext appDbContext;
        public CurrencyRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Currency> GetAllCurrency() => appDbContext.Currency.Include(c => c.Code);

        public Currency GetObjCurrency(string id) => appDbContext.Currency.FirstOrDefault(p => p.CurrencyId == id);
    }
}
