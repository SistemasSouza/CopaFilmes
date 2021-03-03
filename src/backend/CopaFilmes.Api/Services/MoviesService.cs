using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Api.Data.Repositories;

namespace CopaFilmes.Api.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public IList<Movies> GetFinishResult(IList<Movies> movies)
        {
            var filmes = movies.OrderBy(o => o.Titulo).ToList();

            for (int i = 0; i < 2; i++)
            {
                filmes = GenerateResult(filmes);
            }

            return filmes.OrderByDescending(n => n.Nota).ToList();
        }

        public IList<Movies> GetMovies()
        {
            return _moviesRepository.GetAllMovies();
        }

        private List<Movies> GenerateResult(List<Movies> filmes)
        {
            var auxFilmes = new List<Movies>();

            var count = filmes.Count / 2;

            for (int i = 0; i < count; i++)
            {
                var first = filmes.First();
                var last = filmes.Last();

                if(first.Nota > last.Nota)
                {
                  auxFilmes.Add(first);
                }
                else
                {
                  auxFilmes.Add(last);
                }

                filmes.Remove(first);
                filmes.Remove(last);
            }

            return auxFilmes;
        }
    }
}