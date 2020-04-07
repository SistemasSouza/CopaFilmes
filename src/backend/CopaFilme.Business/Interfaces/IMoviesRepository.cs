using CopaFilme.Business.Model;
using System.Collections.Generic;

namespace CopaFilme.Business.Interfaces
{
    public interface IMoviesRepository
    {
        IList<Movies> GetAllMovies();
    }
}
