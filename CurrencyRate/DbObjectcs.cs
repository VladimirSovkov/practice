using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.Domain.Models;

namespace API
{
    public class DbObjectcs
    {
        public static void Initial(IApplicationBuilder app)
        {
            AppDBContext content = app.ApplicationServices.GetRequiredService<AppDBContext>();
            if (!content.Currency.Any())
            {
                //заполнение данными
                content.AddRange(
                    new Currency { CurrencyId = "USD", Code = 111, Name = "Dollar" }
                    );
            }

            content.SaveChanges();
        }


    }
}
