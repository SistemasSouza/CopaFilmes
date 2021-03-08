using System;
using System.Collections.Generic;
using CopaFilmes.Api.Models;
using Xunit;

namespace CopaFilmes.Tests.Fixtures
{
  [CollectionDefinition(nameof(MoviesCollection))]
  public class MoviesCollection : ICollectionFixture<MovieTestsFixture>
  {

  }
  public class MovieTestsFixture : IDisposable
  {
    public List<Movie> MoviesValid()
    {
      return new List<Movie>
      {
        new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
        new Movie {Id = new Random().Next().ToString(),Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7F},
        new Movie {Id = new Random().Next().ToString(),Title = "Oito Mulheres e um Segredo", Year = 2018, Score = 6.3F},
        new Movie {Id = new Random().Next().ToString(),Title = "Hereditário", Year = 2018, Score = 7.8F},
        new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
        new Movie {Id = new Random().Next().ToString(),Title = "Deadpool 2", Year = 2018, Score = 8.1F},
        new Movie {Id = new Random().Next().ToString(),Title = "Han Solo: Uma História Star Wars", Year = 2018, Score = 7.2F},
        new Movie {Id = new Random().Next().ToString(),Title = "Thor: Ragnarok", Year = 2017, Score = 7.6F},
        new Movie {Id = new Random().Next().ToString(),Title = "Te Peguei!", Year = 2018, Score = 7.1F},
        new Movie {Id = new Random().Next().ToString(),Title = "Os Incríveis", Year = 2004, Score = 6.4F},
        new Movie {Id = new Random().Next().ToString(),Title = "A Barraca do Beijo", Year = 2018, Score = 6.4F},
        new Movie {Id = new Random().Next().ToString(),Title = "Tomb Raider: A Origem", Year = 2018, Score = 6.5F},
        new Movie {Id = new Random().Next().ToString(),Title = "Pantera Negra", Year = 2018, Score = 7.5F},
        new Movie {Id = new Random().Next().ToString(),Title = "Hotel Artemis", Year = 2018, Score = 6.3F},
        new Movie {Id = new Random().Next().ToString(),Title = "Superfly", Year = 2018, Score = 5.1F},
        new Movie {Id = new Random().Next().ToString(),Title = "Upgrade", Year = 2018, Score = 7.8F},
      };
    }
    public List<Movie> MoviesSelected()
    {
      return new List<Movie>
      {
        new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
        new Movie {Id = new Random().Next().ToString(),Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7F},
        new Movie {Id = new Random().Next().ToString(),Title = "Oito Mulheres e um Segredo", Year = 2018, Score = 6.3F},
        new Movie {Id = new Random().Next().ToString(),Title = "Hereditário", Year = 2018, Score = 7.8F},
        new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
        new Movie {Id = new Random().Next().ToString(),Title = "Deadpool 2", Year = 2018, Score = 8.1F},
        new Movie {Id = new Random().Next().ToString(),Title = "Han Solo: Uma História Star Wars", Year = 2018, Score = 7.2F},
        new Movie {Id = new Random().Next().ToString(),Title = "Thor: Ragnarok", Year = 2017, Score = 7.6F},
      };
    }

    public static IEnumerable<Object[]> MoviesParameters()
    {
      yield return new object[]
      {
          new List<Movie>
          {
            new Movie { Id = "1", Year = 2010, Score = 6, Title ="Transformers"},
            new Movie { Id = "2", Year = 2011, Score = 10, Title ="Deadpool"},
            new Movie { Id = "3", Year = 2012, Score = 5.5F, Title ="Carros 2"},
            new Movie { Id = "4", Year = 2013, Score = 5, Title ="Os Incriveis"},
            new Movie { Id = "5", Year = 2014, Score = 5, Title ="A espera de um milagre"},
            new Movie { Id = "6", Year = 2015, Score = 7, Title ="A procura da felicidade"},
            new Movie { Id = "7", Year = 2016, Score = 8.5F, Title ="12 homens e um segredo"},
            new Movie { Id = "8", Year = 2017, Score = 10, Title ="Mulher maravilha"},
          },
          new List<Movie>
          {
            new Movie { Id = new Random().Next().ToString(), Year = 2011, Score = 10, Title ="Deadpool"},
            new Movie { Id = new Random().Next().ToString(), Year = 2017, Score = 10, Title ="12 homens e um segredo"},
          },
      };
      yield return new object[]
      {
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
            new Movie {Id = new Random().Next().ToString(),Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7F},
            new Movie {Id = new Random().Next().ToString(),Title = "Oito Mulheres e um Segredo", Year = 2018, Score = 6.3F},
            new Movie {Id = new Random().Next().ToString(),Title = "Hereditário", Year = 2018, Score = 7.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Deadpool 2", Year = 2018, Score = 8.1F},
            new Movie {Id = new Random().Next().ToString(),Title = "Han Solo: Uma História Star Wars", Year = 2018, Score = 7.2F},
            new Movie {Id = new Random().Next().ToString(),Title = "Thor: Ragnarok", Year = 2017, Score = 7.6F},
          },
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
          },
      };
      yield return new object[]
      {
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 5.5F},
            new Movie {Id = new Random().Next().ToString(),Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7F},
            new Movie {Id = new Random().Next().ToString(),Title = "Oito Mulheres e um Segredo", Year = 2018, Score = 6.3F},
            new Movie {Id = new Random().Next().ToString(),Title = "Hereditário", Year = 2018, Score = 7.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 7.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Deadpool 2", Year = 2018, Score = 4.1F},
            new Movie {Id = new Random().Next().ToString(),Title = "Han Solo: Uma História Star Wars", Year = 2018, Score = 7.2F},
            new Movie {Id = new Random().Next().ToString(),Title = "Thor: Ragnarok", Year = 2017, Score = 7.6F},
          },
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Hereditário", Year = 2018, Score = 7.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 7.8F},
          },
      };
      yield return new object[]
      {
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Te Peguei!", Year = 2018, Score = 7.1F},
            new Movie {Id = new Random().Next().ToString(),Title = "Pantera Negra", Year = 2018, Score = 7.5F},
            new Movie {Id = new Random().Next().ToString(),Title = "Hotel Artemis", Year = 2018, Score = 6.3F},
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incríveis", Year = 2004, Score = 6.4F},
            new Movie {Id = new Random().Next().ToString(),Title = "Deadpool 2", Year = 2018, Score = 4.1F},
            new Movie {Id = new Random().Next().ToString(),Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7F},
          },
          new List<Movie>
          {
            new Movie {Id = new Random().Next().ToString(),Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8F},
            new Movie {Id = new Random().Next().ToString(),Title = "Os Incriveis 2", Year = 2018, Score = 8.5F},
          },
      };
    }

    public void Dispose()
    { }
  }
}