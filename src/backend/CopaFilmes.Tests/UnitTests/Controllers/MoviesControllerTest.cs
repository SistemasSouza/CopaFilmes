using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.Controllers;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CopaFilmes.Tests.UnitTests.Controllers
{
    public class MoviesControllerTest
    {
        private readonly Mock<IMoviesService> _moviesServicesMock;

        private readonly MoviesController _controller;
        
        public MoviesControllerTest()
        {
            _moviesServicesMock = new Mock<IMoviesService>();
            _controller = new MoviesController(_moviesServicesMock.Object);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetAll_ShouldReturn200_WhenGetAllMoviesWithSuccess()
        {
          var movies = ValidMovies();

          _moviesServicesMock.Setup(_ => _.GetMoviesAsync()).ReturnsAsync(movies);

          var response = _controller.GetAll().Result;
          var objResult = Assert.IsType<OkObjectResult>(response);
          
          Assert.Equal(200, objResult.StatusCode);
          _moviesServicesMock.Verify(_ => _.GetMoviesAsync(), Times.Once);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetAll_ShouldReturn404_WhenListMoviesIsNullOrZero()
        {
          var movies = new List<Movie>{};

          _moviesServicesMock.Setup(_ => _.GetMoviesAsync()).ReturnsAsync(movies);

          var response = _controller.GetAll().Result;
          var objResult = Assert.IsType<NotFoundObjectResult>(response);
          
          Assert.Equal(404, objResult.StatusCode);
          Assert.Equal("Movies not found", objResult.Value);
          _moviesServicesMock.Verify(_ => _.GetMoviesAsync(), Times.Once);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetFinishResult_ShouldReturn200_WhenResultFinishGeneratedWithSuccess()
        {
          var movies = ValidMovies();
          var moviesChampions = new List<Movie> 
          {
            new Movie {Id = new Random().Next().ToString(),Titulo = "Os Incriveis", Ano = 2010, Nota = 7.5F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Mulher maravilha", Ano = 2016, Nota = 8.5F},
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
          Assert.Equal("it was not possible to generate the result", objResult.Value);
          _moviesServicesMock.Verify(_ => _.GetFinishResult(It.IsAny<List<Movie>>()), Times.Never);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetFinishResult_ShouldReturn400_WhenFinishResultIsNullOrZero()
        {
          var movies = ValidMovies();
          IList<Movie> moviesChampions = null; 

          _moviesServicesMock.Setup(_ => _.GetFinishResult(movies)).Returns(moviesChampions);

          var response = _controller.GetFinishResult(movies).Result;
          var objResult = Assert.IsType<BadRequestObjectResult>(response);
          
          _moviesServicesMock.Verify(_ => _.GetFinishResult(movies), Times.Once);
          Assert.Equal(400, objResult.StatusCode);
          Assert.Equal("it was not possible to generate the result", objResult.Value);
        }

        static private List<Movie> ValidMovies()
        {
          return new List<Movie> 
          {
            new Movie {Id = new Random().Next().ToString(),Titulo = "Os Incriveis 2", Ano = 2018, Nota = 8.5F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Nota = 6.7F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Oito Mulheres e um Segredo", Ano = 2018, Nota = 6.3F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Hereditário", Ano = 2018, Nota = 7.8F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Deadpool 2", Ano = 2018, Nota = 8.1F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Han Solo: Uma História Star Wars", Ano = 2018, Nota = 7.2F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Thor: Ragnarok", Ano = 2017, Nota = 7.6F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Te Peguei!", Ano = 2018, Nota = 7.1F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Os Incríveis", Ano = 2004, Nota = 6.4F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "A Barraca do Beijo", Ano = 2018, Nota = 6.4F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Tomb Raider: A Origem", Ano = 2018, Nota = 6.5F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Pantera Negra", Ano = 2018, Nota = 7.5F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Hotel Artemis", Ano = 2018, Nota = 6.3F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Superfly", Ano = 2018, Nota = 5.1F},
            new Movie {Id = new Random().Next().ToString(),Titulo = "Upgrade", Ano = 2018, Nota = 7.8F},
          };
        }
    }
}