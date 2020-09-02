using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CurrancyRate.Domain.CurrencyRateModel;
using System;
using System.Linq;
using CurrencyRate.API.Dto;
using CurrencyRate.API.Mappers;
using System.Threading.Tasks;
using CurrencyRate.WebsiteConnector.Interface;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using Microsoft.Extensions.Logging;
using CurrencyRate.Application.Converter;

namespace CurrencyRate.API.Controllers
{
    [Route("currencyRate")]
    [Produces("application/json")]
    public class CurrencRateController : Controller
    {
        private readonly ICurrencyRate _currencyRate;
        private readonly ICurrency _currency;
        private readonly IConverter _converter;
        private readonly IConnectorToKazakhstanBank _connectorToKazakhstanBank;
        private readonly IConnectorToUkrainianBank _connectorToUkrainianBank;
        private readonly ILogger<CurrencRateController> _logger;

        public CurrencRateController(ICurrencyRate currencyRate, 
                                        ICurrency currency,
                                        IConverter converter,
                                        IConnectorToKazakhstanBank connectorToKazakhstanBank,
                                        IConnectorToUkrainianBank connectorToUkrainianBank,
                                        ILogger<CurrencRateController> logger)
        {
            _currencyRate = currencyRate;
            _currency = currency;
            _converter = converter;
            _connectorToKazakhstanBank = connectorToKazakhstanBank;
            _connectorToUkrainianBank = connectorToUkrainianBank;
            _logger = logger;
        }

        [HttpGet("getSource")]
        public async Task<List<SourceNameDto>> GetSource()
        {
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

        [HttpPost("LoadData")]
        public IActionResult Test(string dateToStr)
        {
            List<UkrainianBankModel> listDataToUkrBank;
            List<KazakhstanBankModel> listDataToKzBank;
            try
            {
                DateTime date = Convert.ToDateTime(dateToStr);
                listDataToUkrBank = _connectorToUkrainianBank.LoadData(date);
                listDataToKzBank = _connectorToKazakhstanBank.LoadData(date);
            }
            catch (System.FormatException exception)
            {
                _logger.LogWarning("invalid date format. " + exception.Message);
                return BadRequest();
            }
            catch(Exception exception)
            {
                _logger.LogError("error in loading data from the site. " + exception.Message);
                return StatusCode(500);
            }
            _currency.AddDataOnSpecificDate(listDataToUkrBank.MapToCurrency());
            _currencyRate.AddArrayElements(listDataToUkrBank.MapToCurrencyRate());
            _currency.AddDataOnSpecificDate(listDataToKzBank.MapToCurrency());
            _currencyRate.AddArrayElements(listDataToKzBank.MapToCurrencyRate());
            return Ok();
        }

        private DateTime GetCorrectDateTime(string dateToStr)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dateToStr);
                return date;
            }
            catch (Exception exception)
            {
                _logger.LogWarning("invalid date format. " + exception.Message);
                return new DateTime();
            }
        }
    }
}