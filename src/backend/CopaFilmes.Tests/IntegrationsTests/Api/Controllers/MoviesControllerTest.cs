using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using CopaFilmes.Api.Data.Repositories;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using CopaFilmes.Tests.Fixtures;
using CopaFilmes.Tests.IntegrationsTests.Api.Configuration;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace CopaFilmes.Tests.IntegrationsTests.Api.Controllers
{
  public class MoviesControllerTest : BaseIntegrationTest
  {
    private readonly Mock<IMoviesRepository> _moviesRepositoryMock;
    private readonly MovieTestsFixture _movieTestsFixture;
    private readonly MoviesService _movieService;
    public MoviesControllerTest(BaseTestFixture fixture) : base(fixture)
    {
      _moviesRepositoryMock = new Mock<IMoviesRepository>();
      _movieTestsFixture = new MovieTestsFixture();
      _movieService = new MoviesService(_moviesRepositoryMock.Object);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void GetAll_ShouldReturn200_WithListMovies()
    {
      var movies = _movieTestsFixture.MoviesValid();
      
      _moviesRepositoryMock.Setup(_ => _.GetAllMovies()).Returns(movies);

      var response = await Server
                      .CreateRequest($"/api/movies/get-all")
                      .AddHeader("Content-Type", "application/json")
                      .AddHeader("Accept-Encoding", "gzip, deflate")
                      .GetAsync();
      Assert.Equal(200, (int)response.StatusCode);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void GetFinishResult_ShouldReturn200_WhenResultGenerateSuccess()
    {
      var moviesSelected = _movieTestsFixture.MoviesSelected();
      
      var response = await Server
                      .CreateRequest($"/api/movies/finish-result")
                      .AddHeader("Content-Type", "application/json")
                      .AddHeader("Accept-Encoding", "gzip, deflate")
                      .And(req => req.Content = new StringContent(JsonConvert.SerializeObject(moviesSelected), Encoding.UTF8, "application/json"))
                      .PostAsync();

      var content = await response.Content.ReadAsStringAsync();
      var finishResult = JsonConvert.DeserializeObject<List<Movie>>(content);
                      
      Assert.Equal(200, (int)response.StatusCode);
      Assert.Equal(2, finishResult.Count);
      Assert.Equal("Vingadores: Guerra Infinita", finishResult.FirstOrDefault().Title);
      Assert.Equal("Os Incriveis 2", finishResult.LastOrDefault().Title);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public async void GetFinishResult_ShouldReturn400_WhenQuantitySelectedMoviesIsInvalid()
    {
      var moviesSelected = new List<Movie>();
      
      var response = await Server
                      .CreateRequest($"/api/movies/finish-result")
                      .AddHeader("Content-Type", "application/json")
                      .AddHeader("Accept-Encoding", "gzip, deflate")
                      .And(req => req.Content = new StringContent(JsonConvert.SerializeObject(moviesSelected), Encoding.UTF8, "application/json"))
                      .PostAsync();

      var content = await response.Content.ReadAsStringAsync();
                      
      Assert.Equal(400, (int)response.StatusCode);
      Assert.Equal("cannot possible to generate the result the quantity movies is invalid: minimum 8", content);
    }
  }
}