using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CopaFilmes.Tests.IntegrationsTests.Api.Configuration
{
  [Collection("Base Collection")]
  public class BaseIntegrationTest : IDisposable
  {
    public readonly TestServer Server;
    protected readonly HttpClient Client;
    protected readonly IConfiguration _configuration;

    protected BaseTestFixture Fixture { get; }

    protected BaseIntegrationTest(BaseTestFixture fixture)
    {
        Fixture = fixture;
        Server = fixture.Server;
        Client = fixture.Client;
        _configuration = fixture.Configuration;
    }

    public void Dispose()
    {}
  }
}