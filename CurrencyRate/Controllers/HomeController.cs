using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CurrencyRate.Models;
using CurrencyRate.Domain.Interface;
using CurrencyRate.Domain.Models;
using CurrencyRate.Domain.Mock;
using Parse.Infrastructure;


namespace CurrencyRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ICurrencyRate _allCurrencyRate;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("str")]
        public ViewResult ViewString(string id)
        {
            CurrencyRateMock abc = new CurrencyRateMock(new ParseJSON());
            CurrencyRates answer = abc.GetCurrencyRateData(id, 1);
            return View(answer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
