using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CurrancyRate.Domain.CurrencyRateModel;
using System;
using System.Linq;
using CurrencyRate.API.Dto;
using CurrencyRate.API.Mappers;
using System.Threading.Tasks;
using CurrencyRate.Application.Converter;

namespace CurrencyRate.API.Controllers
{
    [Route("currencyRate")]
    [Produces("application/json")]
    public class CurrencRateController : Controller
    {
        private readonly ICurrencyRate _currencyRate;
        private readonly IConverter _converter;

        public CurrencRateController(ICurrencyRate currencyRate, IConverter converter)
        {
            _currencyRate = currencyRate;
            _converter = converter;
        }

        [HttpGet("getSource")]
        public async Task<List<SourceNameDto>> GetSource()
        {
            //"Ukrainian bank"
            List<string> listOfSource = await _currencyRate.GetSource();
            return listOfSource.MapToSourceName();
        }

        [HttpGet("getDate")]
        public List<DateTimeDto> GetDate(string source)
        {
            List<DateTime> listOfDates = _currencyRate.GetAvailableSourceDates(source).ToList();
            return listOfDates.Map();
        }

        [HttpGet("GetListCurrencies")]
        public List<CurrencyNameDto> GetCurrency(string source, string dateToString)
        {
            DateTime date = GetCorrectDateTime(dateToString);
            List<string> currencyList = _currencyRate.GetSourceCurrencySpecificDate(source, date).ToList();
            return currencyList.MapToCurrencyName();
        }

        [HttpGet("GetCurrencyValue")]
        public CurrencyValueDto GetCurrencyValue(string source, string dateToStr, string fromCurrency, string toCurrency, decimal value)
        {
            DateTime date = GetCorrectDateTime(dateToStr);
            decimal fromValue = _currencyRate.GetСurrencyValue(source, date, fromCurrency);
            decimal toValue = _currencyRate.GetСurrencyValue(source, date, toCurrency);
            decimal answer = _converter.CalculateAmount(fromValue, toValue, value);
            answer = Math.Round(answer, 3);
            return answer.Map();
        }

        private DateTime GetCorrectDateTime(string dateToStr)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dateToStr);
                return date;
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }
    }
}