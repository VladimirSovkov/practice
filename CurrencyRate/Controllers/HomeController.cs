using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataBase.Infrastructure;
using API.Models;
using Parse.Infrastructure;
using DataBase.Domain.Model;
using API.Infrastructure;
using Parse.Domain.Model;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CurrencyRateRepository _currencyRateRepository;
        private readonly CurrencyRepository _currencyRepository;

        private readonly List<string> ListSources = new List<string>
        {
            "Ukrainian bank", "National Bank KAZ"
        };

        public HomeController(ILogger<HomeController> logger, CurrencyRateRepository currencyRateRepository, CurrencyRepository currencyRepository)
        {
            _logger = logger;
            _currencyRateRepository = currencyRateRepository;
            _currencyRepository = currencyRepository;
        }

        [HttpGet()]
        public ActionResult Index()
        {
            return View();
        }

        //Получить спсиок источников данных
        [HttpGet("GetSource")]
        public List<string> GetSource()
        {
            return ListSources;
        }

        //получить список доступных дат от источника
        [HttpGet("GetAvailableSourceDates")]
        public List<DateTime> GetAvailableSourceDates(string source)
        {
            //string source = "Ukrainian bank";
            return _currencyRateRepository.GetAvailableSourceDates(source).ToList();
        }

        //выдать список валют источника определенной даты добавления
        [HttpGet("GetSourceCurrencySpecificDate")]
        public List<string> GetSourceCurrencySpecificDate(string source, string dateToStr)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dateToStr);
                var currencyList = _currencyRateRepository.GetSourceCurrencySpecificDate(source, date).ToList();
                return currencyList;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        //GetСurrencyValue(string source, DateTime date, string currency
        //получить значение валюты
        [HttpGet("GetСurrencyValue")]
        public decimal GetСurrencyValue(string source, string dateToStr, string currency, string valueToStr)
        {
            if (source == null || dateToStr == null || currency == null)
            {
                return 0.00m;
            }
            try
            {
                DateTime date = Convert.ToDateTime(dateToStr);
                decimal valueInput = Convert.ToDecimal(valueToStr);
                decimal valueOutput = _currencyRateRepository.GetСurrencyValue(source, date, currency);
                return valueOutput * valueInput;
            }
            catch (Exception)
            {
                return 0.00m;
            }
        }

        [HttpGet("UpdateDataBase")]
        public void UpdateDataBase()
        {
            string date = "02.08.2020";
            ParseXML parseXML = new ParseXML();
            ParseJSON parseJSON = new ParseJSON();
            IEnumerable<XMLModel> enumerableXmlModel = parseXML.GetData(date);;
            List<JSONModel> enumerableJsonModel = parseJSON.GetData(date).ToList();
            List<Currency> enumerableCurrency = MyConverter.ToCurrency(enumerableJsonModel);
            _currencyRepository.AddDataOnSpecificDate(enumerableCurrency);
            enumerableCurrency = MyConverter.ToCurrency(enumerableXmlModel.ToList()).ToList();
            _currencyRepository.AddDataOnSpecificDate(enumerableCurrency);
            List<DataBase.Domain.Model.CurrencyRate> currencyRates = MyConverter.ToCurrencyRate(enumerableJsonModel);
            _currencyRateRepository.AddArrayElements(currencyRates);
            currencyRates = MyConverter.ToCurrencyRate(enumerableXmlModel.ToList());
            _currencyRateRepository.AddArrayElements(currencyRates);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
