using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CurrencyRate.IntegrationTests.TestKit
{
    class TestDriver : ITestDriver, IDisposable
    {
        private readonly IWebHost _webHost;
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestDriver(Type startupType, string environment = "Development")
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(startupType).Location))
                .AddJsonFile("appsettings.test.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var webHostBuilder = new WebHostBuilder()
                .UseStartup<AdminApiStartup>()
                .UseEnvironment(environment)
                .UseConfiguration(configuration);

            _server = new TestServer(webHostBuilder);   

            _webHost = _server.Host;
            _client = _server.CreateClient();
        }

        public IServiceProvider Services()
        {
            return _webHost.Services;
        }

        public HttpClient HttpClient()
        {
            return _client; 
        }

        public async Task SeedDatabase()
        {
            IDbSeeder dbSeeder = Services().GetService<IDbSeeder>();
            if (dbSeeder == null)
            {
                return;
            }

            await dbSeeder.Seed();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        public async Task<TResponse> HttpClientGetAsync<TResponse>(
            string requestUri, 
            HttpStatusCode statusCode = HttpStatusCode.OK, 
            IReadOnlyDictionary<string, string> headers = null)
        {
            SetRequestHeaders(headers);
            //_client.DefaultRequestHeaders.Add();
            var response = await _client.GetAsync(requestUri);
            if (response.StatusCode != statusCode)
            {
                throw new HttpRequestException($"Status code: {response.StatusCode}");
            }
            string responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseString);
        }

        private void SetRequestHeaders(IReadOnlyDictionary<string, string> headers)
        {
            if (headers == null)
            {
                return;
            }

            foreach (string headerName in headers.Keys)
            {
                _client.DefaultRequestHeaders.Add(headerName, headers[headerName]);
            }
        }
    }
}
