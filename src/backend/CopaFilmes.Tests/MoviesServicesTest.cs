using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using CopaFilmes.Api.Data.Repositories;

namespace CopaFilmes.Tests
{
    public class MoviesServicesTest
    {
        private readonly Mock<IMoviesService> _moviesServiceMock;
        private readonly Mock<IMoviesRepository> _moviesRepository;
        private readonly MoviesService _service;

        public MoviesServicesTest()
        {
            _moviesServiceMock = new Mock<IMoviesService>();
            _moviesRepository =new Mock<IMoviesRepository>();

            _service = new MoviesService(_moviesRepository.Object);
        }

        [Fact]
        public void Test1()
        {
            var moviesSelecteds = new List<Movies>
            {
               new Movies { Id = "1", Ano = 2010, Nota = 6, Titulo ="Transformers"},
               new Movies { Id = "2", Ano = 2011, Nota = 10, Titulo ="Deadpool"},
               new Movies { Id = "3", Ano = 2012, Nota = 5.5F, Titulo ="Carros 2"},
               new Movies { Id = "4", Ano = 2013, Nota = 5, Titulo ="Os Incriveis"},
               new Movies { Id = "5", Ano = 2014, Nota = 5, Titulo ="A espera de um milagre"},
               new Movies { Id = "6", Ano = 2015, Nota = 7, Titulo ="A procura da felicidade"},
               new Movies { Id = "7", Ano = 2016, Nota = 8.5F, Titulo ="12 homens e um segredo"},
               new Movies { Id = "8", Ano = 2017, Nota = 10, Titulo ="Mulher maravilha"},
            };

            var moviesChampions = new List<Movies> 
            {
              new Movies { Id = "2", Ano = 2011, Nota = 9, Titulo ="Deadpool"},
              new Movies { Id = "8", Ano = 2017, Nota = 10, Titulo ="Mulher maravilha"},
            };

            _moviesServiceMock.Setup(_ => _.GetFinishResult(moviesSelecteds)).Returns(moviesChampions);

            var result = _service.GetFinishResult(moviesSelecteds);
            
            Assert.Equal(2, result.Count);
            Assert.Equal("Deadpool", result.FirstOrDefault().Titulo);
            Assert.Equal("Mulher maravilha", result.LastOrDefault().Titulo);
        }
    }
}
