using System;
using System.Net.Http;
using CopaFilmes.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace CopaFilmes.Tests.IntegrationsTests.Api.Configuration
{
  public class BaseTestFixture : IDisposable
  {
    public readonly TestServer Server;
    public readonly HttpClient Client;
    public readonly IConfiguration Configuration;

    public BaseTestFixture()
    {

      Server = new TestServer(new WebHostBuilder()
                    .UseEnvironment("testing")
                    .UseStartup<Startup>()
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                      config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                          .AddJsonFile("appsettings.testing.json", true);
                      config.AddEnvironmentVariables();
                    }));

      Configuration = Server.Host.Services.GetService(typeof(IConfiguration)) as IConfiguration;

      Client = Server.CreateClient();
    }


    public void Dispose()
    {
      Server.Dispose();
      Client.Dispose();
    }
  }
}