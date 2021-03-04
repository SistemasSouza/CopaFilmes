using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Api.Data.Repositories;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Services
{
  public class MoviesService : IMoviesService
  {
    const int FINALISTQUANTITY = 2;
    private readonly IMoviesRepository _moviesRepository;

    public MoviesService(IMoviesRepository moviesRepository)
    {
      _moviesRepository = moviesRepository;
    }

    public IList<Movie> GetFinishResult(IList<Movie> movies)
    {
      try
      {
        movies = movies.OrderBy(_ => _.Title).ToList();

        return GenerateResultFinal(movies);
      }
      catch (System.Exception)
      {
        throw new System.Exception("Cannot possible generate finish result");
      }
    }

    public async Task<IList<Movie>> GetAllMoviesAsync()
    {
      try
      {
        return await Task.Run(() => _moviesRepository.GetAllMovies());
      }
      catch (System.Exception ex)
      {
        throw ex;
      }
    }

    private List<Movie> GenerateResultFinal(IList<Movie> movies)
    {
      var moviesClassifiedInLevelOne = GenerateResultLevelOne(movies);
      var moviesFinalist = new List<Movie>();


      for (int i = 0; i < FINALISTQUANTITY; i++)
      {
        var auxMovies = moviesClassifiedInLevelOne.Take(FINALISTQUANTITY).OrderBy(_ => _.Title);

        var first = auxMovies.First();
        var second = auxMovies.Last();

        if (first.Score > second.Score || first.Score == second.Score)
        {
          moviesFinalist.Add(first);
        }
        else
        {
          moviesFinalist.Add(second);
        }
        moviesClassifiedInLevelOne.Remove(first);
        moviesClassifiedInLevelOne.Remove(second);
        auxMovies = null;
      }
      return moviesFinalist.OrderByDescending(_ => _.Score).ThenBy(_ => _.Title).ToList();
    }
    private List<Movie> GenerateResultLevelOne(IList<Movie> movies)
    {
      var auxMovies = new List<Movie>();

      var count = movies.Count / FINALISTQUANTITY;

      for (int i = 0; i < count; i++)
      {
        var first = movies.First();
        var last = movies.Last();

        if (first.Score > last.Score || first.Score == last.Score)
        {
          auxMovies.Add(first);
        }
        else
        {
          auxMovies.Add(last);
        }

        movies.Remove(first);
        movies.Remove(last);
      }

      return auxMovies;
    }
  }
}