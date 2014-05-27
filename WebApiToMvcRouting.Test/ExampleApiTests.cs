using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiToMvcRouting.Test
{
    [TestClass]
    public class ExampleApiTests
    {

        private HttpConfiguration _config;
        private HttpServer _server;
        private HttpMessageInvoker _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _config = new HttpConfiguration();
            WebApiConfig.Register(_config);
            _server = new HttpServer(_config);
            _client = new HttpMessageInvoker(_server);
        }

        [TestMethod]
        public void ShouldReturnMvcRoute()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/example/mvcroute"))
            {
                using (var response = _client.SendAsync(request, CancellationToken.None).Result)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    Assert.AreEqual("\"http://localhost/Other\"", responseContent);
                }
            }
        }

        [TestMethod]
        public void ShouldReturnApiRoute()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/example/apiroute"))
            {
                using (var response = _client.SendAsync(request, CancellationToken.None).Result)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    Assert.AreEqual("\"http://localhost/api/Example/MvcRoute\"", responseContent);
                }
            }
        }
    }
}