using CopaFilmes.Api.Models;
using System.Collections.Generic;

namespace CopaFilmes.Api.Services
{
    public interface IMoviesService
    {
        IList<Movies> GetMovies();
        IList<Movies> GetFinishResult(IList<Movies> movies);
    }
}
