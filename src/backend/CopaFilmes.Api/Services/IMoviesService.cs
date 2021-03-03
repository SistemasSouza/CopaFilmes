using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Services
{
  public interface IMoviesService
  {
    Task<IList<Movie>> GetAllMoviesAsync();
    IList<Movie> GetFinishResult(IList<Movie> movies);
  }
}
