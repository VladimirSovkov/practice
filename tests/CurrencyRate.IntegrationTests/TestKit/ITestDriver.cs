
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyRate.IntegrationTests.TestKit
{
    public interface ITestDriver : IDisposable
    {
        IServiceProvider Services();
        
        Task<TResponse> HttpClientGetAsync<TResponse>(
           string requestUri,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            IReadOnlyDictionary<string, string> headers = null);
        
        Task HttpClientPostAsync(
            string Uri,
            object body,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            IReadOnlyDictionary<string, string> headers = null);
        
        Task SeedDatabase();
    }
}
