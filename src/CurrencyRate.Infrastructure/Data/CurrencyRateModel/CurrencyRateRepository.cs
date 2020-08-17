using CurrancyRate.Domain.CurrencyRateModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRate.Infrastructure.Data.CurrencyRateModel
{
    public class CurrencyRateRepository : ICurrencyRate
    {
        private readonly CurrencyRateContext _dbContext;
        public CurrencyRateRepository(CurrencyRateContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        //выдать первый попавшийся год ресурса 
        public CurrancyRate.Domain.CurrencyRateModel.CurrencyRate GetCurrencyRate(DateTime date, string source) => _dbContext.CurrencyRate.Where(p => p.Source == source).FirstOrDefault(p => p.Date == date);

        //все даты заполнения таблицы CurrencyRate
        public IEnumerable<DateTime> GetAvailableSourceDates(string source)
        {
            var currencyRate = _dbContext.CurrencyRate.Where(c => c.Source == source).Select(c => c.Date).Distinct();
            return currencyRate;
        }

        //добавить в талицу CurrencyRate массив значений 
        public void AddArrayElements(List<CurrancyRate.Domain.CurrencyRateModel.CurrencyRate> arrayCurrencyRate)
        {
            if (arrayCurrencyRate.Count() == 0)
            {
                return;
            }
            DateTime date = arrayCurrencyRate[0].Date;
            string source = arrayCurrencyRate[0].Source;
            var abc = GetCurrencyRate(date, source);
            if (GetCurrencyRate(date, source) == null)
            {
                _dbContext.CurrencyRate.AddRange(arrayCurrencyRate);
                _dbContext.SaveChanges();
            }
        }

        //выдать значение влюты определеного источника и даты
        public decimal GetСurrencyValue(string source, DateTime date, string currency)
        {
            var abc = _dbContext.CurrencyRate.Where(s => s.Source == source).Where(d => d.Date == date).FirstOrDefault(c => c.CurrencyId == currency);
            return abc.Rate;
        }

        public IEnumerable<string> GetSourceCurrencySpecificDate(string source, DateTime date)
        {
            return _dbContext.CurrencyRate.Where(s => s.Source == source).Where(d => d.Date == date).Select(c => c.CurrencyId).Distinct();
        }

        public Task<List<string>> GetSource()
        {
            return _dbContext.CurrencyRate.Select(s => s.Source).Distinct().ToListAsync();
        }
    }
}
