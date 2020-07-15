using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    class Program
    {
        static void Main()
        {
            using (var db = new MyDB())
            {
                var currency = new Currency { 
                    CurrencyId = "EUR",
                    Code = 111,
                    Name = "EURO"
                };
                db.Currencies.Add(currency);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Currencies
                            orderby b.CurrencyId
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CurrencyId);
                }

            }

        }
    }
}
