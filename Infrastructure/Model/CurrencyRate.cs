using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Model
{
    public class CurrencyRate
    {
        public int CurrencyRateId { get; set; }
        public double Rate { get; set; }
        public string CurrencyId { get; set; }
        public DateTime Date { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
