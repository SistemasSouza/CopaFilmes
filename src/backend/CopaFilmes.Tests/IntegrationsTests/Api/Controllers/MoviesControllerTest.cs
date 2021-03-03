using System.Collections.Generic;
using CopaFilmes.Api.Data.Repositories;
using CopaFilmes.Api.Models;
using CopaFilmes.Tests.IntegrationsTests.Api.Configuration;
using Moq;
using Xunit;

namespace CopaFilmes.Tests.IntegrationsTests.Api.Controllers
{
    public class MoviesControllerTest : BaseIntegrationTest
    {
        public MoviesControllerTest(BaseTestFixture fixture) : base(fixture)
        {
            
        }

        [Fact(Skip = "In Progress")]
        [Trait("Category", "Integration")]
        public void GetAll_ShouldReturn200_WithMovies()
        {
        }
    }
}