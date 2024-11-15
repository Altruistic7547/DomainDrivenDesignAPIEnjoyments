using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyForge.Application.UnitTests
{
    [TestClass]
    public class RouteTestBase
    {
        public string _baseUrl;

        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public RouteTestBase(string baseUrl)
        {
            _baseUrl = baseUrl;
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        public async Task RouteTestAsync(string action, HttpMethod httpMethod, object data = default)
        {
            var url = $"{_baseUrl}/{action}";
            var request = new HttpRequestMessage(httpMethod, url);

            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(response.RequestMessage?.Method, httpMethod);
            Assert.AreEqual(request.RequestUri?.ToString(), response.RequestMessage?.RequestUri?.ToString());
        }
    }
}
