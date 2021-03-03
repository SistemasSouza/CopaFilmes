using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using CopaFilmes.Api.Data.Repositories;
using CopaFilmes.Tests.Fixtures;

namespace CopaFilmes.Tests
{
  [Collection(nameof(MoviesCollection))]
  public class MoviesServicesTest
  {
    private readonly Mock<IMoviesService> _moviesServiceMock;
    private readonly Mock<IMoviesRepository> _moviesRepository;
    private readonly MoviesService _service;

    private readonly MovieTestsFixture _movieTestsFixture;

    public MoviesServicesTest(MovieTestsFixture movieTestsFixture)
    {
      _moviesServiceMock = new Mock<IMoviesService>();
      _moviesRepository = new Mock<IMoviesRepository>();

      _service = new MoviesService(_moviesRepository.Object);
      _movieTestsFixture = movieTestsFixture;
    }

    [Theory]
    [MemberData(nameof(MovieTestsFixture.MoviesParameters), MemberType = typeof(MovieTestsFixture))]
    [Trait("Category", "Unit")]
    public void GeneratedFinishResult_ShouldReturn_TwoMoviesFinalist(List<Movie> movies, List<Movie> moviesChampions)
    {
      var moviesSelecteds = movies;

      _moviesServiceMock.Setup(_ => _.GetFinishResult(moviesSelecteds)).Returns(moviesChampions);

      var result = _service.GetFinishResult(moviesSelecteds);

      Assert.Equal(2, result.Count);
      Assert.Equal(moviesChampions.FirstOrDefault().Title, result.FirstOrDefault().Title);
      Assert.Equal(moviesChampions.LastOrDefault().Title, result.LastOrDefault().Title);
    }
  }
}
