using System.Collections.Generic;
using CopaFilmes.Api.Models;

namespace CopaFilmes.Api.Data.Repositories
{
    public interface IMoviesRepository
    {
        IList<Movies> GetAllMovies();
    }
}
