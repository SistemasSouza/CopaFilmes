using CopaFilme.Business.Model;
using System.Collections.Generic;

namespace CopaFilme.Business.Interfaces
{
    public interface IMoviesService
    {
        IList<Movies> GetMovies();
        IList<Movies> GetFinishResult(IList<Movies> movies);
    }
}
