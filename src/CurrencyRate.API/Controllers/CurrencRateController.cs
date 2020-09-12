using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CurrencyRate.Domain.CurrencyRateModel;
using System;
using System.Linq;
using CurrencyRate.API.Dto;
using CurrencyRate.API.Mappers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net;
using CurrencyRate.Domain.DataRecipient.Interface;
using CurrencyRate.Application.RateConverter;

namespace CurrencyRate.API.Controllers
{
    [Route("currencyRate")]
    [Produces("application/json")]
    public class CurrencRateController : Controller
    {
        private readonly ICurrencyRate _currencyRate;
        private readonly ICurrency _currency;
        private readonly ILogger<CurrencRateController> _logger;
        private readonly IReceivingCurrency _receivingCurrency;
        private readonly IConverter _converter;

        public CurrencRateController(ICurrencyRate currencyRate,
                                        ICurrency currency,
                                        ILogger<CurrencRateController> logger,
                                        IReceivingCurrency receivingCurrency,
                                        IConverter converter)
        {
            _currencyRate = currencyRate;
            _currency = currency;
            _logger = logger;
            _receivingCurrency = receivingCurrency;
            _converter = converter;
        }

        [HttpGet("getSource")]
        public List<SourceNameDto> GetSource()
        {
            return _receivingCurrency.GetSourcesList().MapToSourceName();
        }

        [HttpGet("GetListCurrencies")]
        public List<CurrencyNameDto> GetCurrency(string source)
        {
            List<string> currencyList = _currencyRate.GetSourceCurrencyList(source).ToList();
            return currencyList.MapToCurrencyName();
        }

        [HttpPost("GetValue")]
        public async Task<ActionResult<CurrencyValueDto>> GetValue([FromBody]ParametersForGetTotalValue parameters)
        {
            if (parameters.Date > DateTime.Now || parameters.Date <= new DateTime(2000, 01, 01))
            {
                _logger.LogWarning($"Incorrect date ({parameters.Date})");
                return BadRequest("invalid date range");
            }
            if (!await _currencyRate.ThereIsSuchData(parameters.Source, parameters.Date))
            {
                var DataDownloadStatus = LoadData(new CurrencyRateLoadParameters { Date = parameters.Date, Source = parameters.Source });
                if (DataDownloadStatus != HttpStatusCode.OK)
                {
                    return StatusCode(500);
                }
            }

            decimal answer = 0;
            try
            {
                decimal fromValue = _currencyRate.GetСurrencyValue(parameters.Source, parameters.Date, parameters.FromCurrency);
                decimal toValue = _currencyRate.GetСurrencyValue(parameters.Source, parameters.Date, parameters.ToCurrency);
                answer = _converter.Convert(fromValue, toValue, parameters.Value);
            }
            catch(NullReferenceException exception)
            {
                _logger.LogError(exception.Message);
                return BadRequest("no data for one of the currencies");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return StatusCode(500);
            }

            answer = Math.Round(answer, 3);
            return answer.Map();
        }

        [HttpPost("LoadData")]
        public HttpStatusCode LoadData([FromBody]CurrencyRateLoadParameters parameters)
        {
            try
            {
                var currencyList = _receivingCurrency.GetCurrencies(parameters.Source, parameters.Date);
                var currencyRateList = _receivingCurrency.GetCurrencyRates(parameters.Source, parameters.Date);
                _currency.AddDataOnSpecificDate(currencyList);
                _currencyRate.AddArrayElements(currencyRateList);
            }
            catch(ArgumentException exception)
            {
                _logger.LogError("Invalid date entered in the request \"currencyRate.LoadData\" " + exception.Message);
                return HttpStatusCode.BadRequest;
            }
            catch(Exception exception)
            {
                _logger.LogError("error in loading data from the site. " + exception.Message);
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.OK;
        }
    }
}