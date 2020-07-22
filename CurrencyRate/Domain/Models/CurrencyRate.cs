using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyRate.Domain.Models
{
    public class CurrencyRates
    {
        public double Rate { get; set; }
        public string CurrencyId { get; set; }
        public DateTime Date { get; set; }

        //public virtual Currency Currencies { get; set; }
    }
}
