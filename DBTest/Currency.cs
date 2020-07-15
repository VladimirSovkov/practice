using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    public class Currency
    {
        public string CurrencyId { get; set; }
        public int Code { get; set; }
        public string Name { get; set;  }

        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }
    }
}
