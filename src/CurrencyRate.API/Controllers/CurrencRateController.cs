using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CurrancyRate.Domain.CurrencyRateModel;
using System;
using System.Linq;
using CurrencyRate.API.Dto;
using CurrencyRate.API.Mappers;
using System.Threading.Tasks;

namespace CurrencyRate.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Route("v{version:apiVersion}/currencyRate")]
    [Produces("application/json")]
    public class CurrencRateController : Controller
    {
        private readonly ICurrencyRate _currencyRate;

        public CurrencRateController(ICurrencyRate currencyRate)
        {
            _currencyRate = currencyRate;
        }

        [HttpGet]
        public async Task<List<SourceNameDto>> GetSource()
        {
            //"Ukrainian bank"
            List<string> listOfSource = await _currencyRate.GetSource();
            return listOfSource.Map();
        }

        [HttpGet("getDate")]
        public List<DateTimeDto> GetDate()//add string source
        {
            string source = "Ukrainian bank";
            List<DateTime> listOfDates = _currencyRate.GetAvailableSourceDates(source).ToList();
            return listOfDates.Map();
        }

        [HttpGet("GetCurrencySpecificDateAndSource")]
        public List<string> GetCurrency()// add string source, DateTime date
        {
            string source = "Ukrainian bank";
            DateTime date = new DateTime(2020,03,20);
            return _currencyRate.GetSourceCurrencySpecificDate(source, date).ToList();
        }

        [HttpGet("GetCurrencyValue")]
        public CurrencyValueDto GetCurrencyValue()//add string source, DateTime date, sring currency,  decimal value
        {
            DateTime date = new DateTime(2020,03,20);
            string source = "Ukrainian bank";
            string currency = "USD";
            decimal listOfDecimal = _currencyRate.GetСurrencyValue(source, date, currency);
            return listOfDecimal.Map();
        }
    }
}