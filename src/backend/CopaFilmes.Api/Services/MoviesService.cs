using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Api.Data.Repositories;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public IList<Movie> GetFinishResult(IList<Movie> movies)
        {
            var filmes = movies.OrderBy(o => o.Titulo).ToList();

            for (int i = 0; i < 2; i++)
            {
                filmes = GenerateResult(filmes);
            }

            return filmes.OrderBy(n => n.Nota).ThenBy(t => t.Titulo).ToList();
        }

        public async Task<IList<Movie>> GetMoviesAsync()
        {
            return await _moviesRepository.GetAllMoviesAsync();
        }

        private List<Movie> GenerateResult(List<Movie> filmes)
        {
            var auxFilmes = new List<Movie>();

            var count = filmes.Count / 2;

            for (int i = 0; i < count; i++)
            {
                var first = filmes.First();
                var last = filmes.Last();

                if(first.Nota > last.Nota || first.Nota == last.Nota)
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