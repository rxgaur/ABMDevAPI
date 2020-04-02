using ABM.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace ABM.IntegrationTest
{
    public class TestClientProvider
    {
        public HttpClient Client { get; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }


}