using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace Skillustrator.Tests.Integration.Api
{
    public class TestWebServer
    {
        private const string URL_BASE = "http://localhost";
        private const string URLS_SERVED = "http://*:80";
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestWebServer()
        {            
            _server = new TestServer(new WebHostBuilder()
                .UseUrls(URLS_SERVED)
                .UseStartup<Startup>());
            _server.BaseAddress = new Uri(URL_BASE);
            
            _client = _server.CreateClient();
        }

        public async Task<string> GetUrlResponse(string relativeUrl)
        {
            var response = await _client.GetAsync(URL_BASE + relativeUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostToUrl(string relativeUrl, StringContent pocoToPost)
        {
            var jsonInString = JsonConvert.SerializeObject(pocoToPost);
            var postContent = new StringContent(jsonInString, Encoding.UTF8, "application/json");
            
            var request = $"{URL_BASE}{relativeUrl}";
            Console.WriteLine($"TestServer.PostToUrl POST REQUEST: {request}. BODY: {postContent}");
            var response = await _client.PostAsync(request, postContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

    }
}

