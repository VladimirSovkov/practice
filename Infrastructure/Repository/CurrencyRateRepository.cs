using Infrastructure.Interface;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class CurrencyRateRepository : ICurrencyRate
    {
        private readonly AppDBContext appDbContext;
        public CurrencyRateRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<CurrencyRate> GetAllCurrencyRate() => appDbContext.CurrencyRate;

        public CurrencyRate GetObjCurrencyRate(string id) => appDbContext.CurrencyRate.FirstOrDefault(p => p.CurrencyId == id);
    }
}
