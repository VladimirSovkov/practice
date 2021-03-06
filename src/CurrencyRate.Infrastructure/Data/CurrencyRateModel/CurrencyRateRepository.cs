﻿using CurrencyRate.Domain.CurrencyRateModel;
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

        public CurrencyRate.Domain.CurrencyRateModel.CurrencyRate GetCurrencyRate(DateTime date, string source) => _dbContext.CurrencyRate.Where(p => p.Source == source).FirstOrDefault(p => p.Date == date);

        public IEnumerable<DateTime> GetAvailableSourceDates(string source)
        {
            var currencyRate = _dbContext.CurrencyRate.Where(c => c.Source == source).Select(c => c.Date).Distinct();
            return currencyRate;
        }

        public void AddArrayElements(List<CurrencyRate.Domain.CurrencyRateModel.CurrencyRate> arrayCurrencyRate)
        {
            if (arrayCurrencyRate.Count() == 0)
            {
                return;
            }
            DateTime date = arrayCurrencyRate[0].Date;
            string source = arrayCurrencyRate[0].Source;
            if (GetCurrencyRate(date, source) == null)
            {
                _dbContext.CurrencyRate.AddRange(arrayCurrencyRate);
                _dbContext.SaveChanges();
            }
        }

        public decimal GetСurrencyValue(string source, DateTime date, string currency)
        {
            var currencyRate = _dbContext.CurrencyRate.Where(s => s.Source == source).Where(d => d.Date == date).FirstOrDefault(c => c.CurrencyId == currency);
            if (currencyRate == null)
            {
                throw new NullReferenceException($"This object is not in the database. source = {source}, date = {date}, currency = {currency}");
            }
            return currencyRate.Rate;
        }

        public IEnumerable<string> GetSourceCurrencyList(string source)
        {
            return _dbContext.CurrencyRate
                    .Where(s => s.Source == source)
                    .Select(c => c.CurrencyId)
                    .Distinct();
        }

        public Task<List<string>> GetSource()
        {
            return _dbContext.CurrencyRate.Select(s => s.Source).Distinct().ToListAsync();
        }

        public async Task<bool> ThereIsSuchData(string source, DateTime date)
        { 
            var listData = await _dbContext.CurrencyRate
                           .Where (p => p.Source == source)
                           .FirstOrDefaultAsync(p => p.Date == date);
            if (listData == null)
            {
                return false;
            }
            return true;
        }

    }
}
