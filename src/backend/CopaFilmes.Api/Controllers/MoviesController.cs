using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private readonly IMoviesService _moviesService;

    public MoviesController(IMoviesService moviesService)
    {
      _moviesService = moviesService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
      var movies = await _moviesService.GetAllMoviesAsync();

      if(movies.Count <= 0)
        return NotFound("Movies not found");

      return Ok(movies);
    }

    [HttpPost("finish-result")]
    public async Task<IActionResult> GetFinishResult(List<Movie> movies)
    {
      if (movies == null || movies.Count < 8)
      {
        return BadRequest("cannot possible to generate the result the quantity movies is invalid: minimum 8");
      }

      var moviesResult = await Task.Run(() => _moviesService.GetFinishResult(movies));

      return Ok(moviesResult);
    }
  }
}