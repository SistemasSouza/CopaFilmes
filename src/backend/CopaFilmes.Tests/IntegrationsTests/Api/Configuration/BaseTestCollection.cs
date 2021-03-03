using Xunit;

namespace CopaFilmes.Tests.IntegrationsTests.Api.Configuration
{

  [CollectionDefinition("Base collection")]
  public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
  {
  }
}