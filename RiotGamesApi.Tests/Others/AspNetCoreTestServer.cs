using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RiotGamesApi.Web;

namespace RiotGamesApi.Tests.Others
{
    public class AspNetCoreTestServer
    {
        public IServiceProvider ServiceProvider { get; }

        public TestServer Server { get; }

        public HttpClient Client { get; }

        public AspNetCoreTestServer()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
            ServiceProvider = Server.Host.Services;
        }
    }
}