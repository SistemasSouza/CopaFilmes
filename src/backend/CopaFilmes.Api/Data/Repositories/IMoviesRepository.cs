using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.Models;

namespace CopaFilmes.Api.Data.Repositories
{
    public interface IMoviesRepository
    {
        IList<Movie> GetAllMovies();
    }
}
