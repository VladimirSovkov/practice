using DataBase.Domain.Interface;
using DataBase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase.Infrastructure
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly AppDBContext _appDbContext;
        public CurrencyRateRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        //выдать первый попавшийся год ресурса 
        public CurrencyRate GetCurrencyRate(DateTime date, string source) => _appDbContext.CurrencyRate.Where(p => p.Source == source).FirstOrDefault(p => p.Date == date);

        //все даты заполнения таблицы CurrencyRate
        public IEnumerable<DateTime> GetAvailableSourceDates(string source)
        {
            var currencyRate = _appDbContext.CurrencyRate.Where(c => c.Source == source).Select(c => c.Date).Distinct();
            return currencyRate;
        }

        //добавить в талицу CurrencyRate массив значений 
        public void AddArrayElements(List<CurrencyRate> arrayCurrencyRate)
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
                _appDbContext.CurrencyRate.AddRange(arrayCurrencyRate);
                _appDbContext.SaveChanges();
            }
        }

        //выдать значение влюты определеного источника и даты
        public decimal GetСurrencyValue(string source, DateTime date, string currency)
        {
            var abc = _appDbContext.CurrencyRate.Where(s => s.Source == source).Where(d => d.Date == date).FirstOrDefault(c => c.CurrencyId == currency);
            return abc.Rate;
        }

        public IEnumerable<string> GetSourceCurrencySpecificDate(string source, DateTime date)
        {
            return _appDbContext.CurrencyRate.Where(s => s.Source == source).Where(d => d.Date == date).Select(c => c.CurrencyId).Distinct();
        }
    }
}
