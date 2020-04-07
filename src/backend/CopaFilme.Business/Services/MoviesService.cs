using CopaFilme.Business.Interfaces;
using CopaFilme.Business.Model;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilme.Business.Services
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

            return filmes;
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

                auxFilmes.Add(first.Nota > last.Nota ? first : last);
                filmes.Remove(first);
                filmes.Remove(last);
            }

            return auxFilmes;
        }
    }
}