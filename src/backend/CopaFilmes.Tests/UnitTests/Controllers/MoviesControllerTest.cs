using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.Controllers;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using CopaFilmes.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CopaFilmes.Tests.UnitTests.Controllers
{
  [Collection(nameof(MoviesCollection))]
  public class MoviesControllerTest
  {
    private readonly Mock<IMoviesService> _moviesServicesMock;

    private readonly MoviesController _controller;
    private readonly MovieTestsFixture _movieTestsFixture;
    public MoviesControllerTest(MovieTestsFixture movieTestsFixture)
    {
      _moviesServicesMock = new Mock<IMoviesService>();
      _controller = new MoviesController(_moviesServicesMock.Object);
      _movieTestsFixture = movieTestsFixture;
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void GetAll_ShouldReturn200_WhenGetAllMoviesWithSuccess()
    {
      var movies = _movieTestsFixture.MoviesValid();

      _moviesServicesMock.Setup(_ => _.GetAllMoviesAsync()).ReturnsAsync(movies);

      var response = _controller.GetAll().Result;
      var objResult = Assert.IsType<OkObjectResult>(response);

      Assert.Equal(200, objResult.StatusCode);
      _moviesServicesMock.Verify(_ => _.GetAllMoviesAsync(), Times.Once);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void GetAll_ShouldReturn404_WhenListMoviesIsNullOrZero()
    {
      var movies = new List<Movie> { };

      _moviesServicesMock.Setup(_ => _.GetAllMoviesAsync()).ReturnsAsync(movies);

      var response = _controller.GetAll().Result;
      var objResult = Assert.IsType<NotFoundObjectResult>(response);

      Assert.Equal(404, objResult.StatusCode);
      Assert.Equal("Movies not found", objResult.Value);
      _moviesServicesMock.Verify(_ => _.GetAllMoviesAsync(), Times.Once);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void GetFinishResult_ShouldReturn200_WhenResultFinishGeneratedWithSuccess()
    {
      var movies = _movieTestsFixture.MoviesValid();
      var moviesChampions = new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis", Year = 2010, Score = 7.5F},
            new Movie {Id = new Random().Next().ToString(),Title = "Mulher maravilha", Year = 2016, Score = 8.5F},
          };

      _moviesServicesMock.Setup(_ => _.GetFinishResult(movies)).Returns(moviesChampions);

      var response = _controller.GetFinishResult(movies).Result;
      var objResult = Assert.IsType<OkObjectResult>(response);

      var data = objResult.Value as List<Movie>;

      Assert.Equal(200, objResult.StatusCode);
      Assert.Equal(2, data.Count);
      _moviesServicesMock.Verify(_ => _.GetFinishResult(It.IsAny<List<Movie>>()), Times.Once);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void GetFinishResult_ShouldReturn400_WhenQuantityMoviesSelectedIsInvalid()
    {
      var response = _controller.GetFinishResult(null).Result;
      var objResult = Assert.IsType<BadRequestObjectResult>(response);

      Assert.Equal(400, objResult.StatusCode);
      Assert.Equal("cannot possible to generate the result the quantity movies is invalid: minimum 8", objResult.Value);
      _moviesServicesMock.Verify(_ => _.GetFinishResult(It.IsAny<List<Movie>>()), Times.Never);
    }
  }
}