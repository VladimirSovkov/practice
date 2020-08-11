﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyRate.Infrastructure.Startup
{
    public interface IBaseStartup : IStartup
    {
        void AddServices( IServiceCollection services );
    }
}
