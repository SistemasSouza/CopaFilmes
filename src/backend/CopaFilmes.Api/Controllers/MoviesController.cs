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

        [HttpGet("obter-todos-filmes")]
        public async Task<ActionResult> GetAll()
        {
          var movies = await _moviesService.GetMoviesAsync();

          if(movies == null || movies.Count <= 0)
            return NotFound("Movies not found");

            return Ok(movies);
        }

        [HttpPost("resultado-final")]
        public async Task<IActionResult> GetFinishResult(List<Movie> movies)
        {
          if(movies == null || movies.Count < 8)
          {
            return BadRequest("it was not possible to generate the result");
          }

          var moviesResult = await Task.Run(() => _moviesService.GetFinishResult(movies));

          if(moviesResult == null || moviesResult.Count <= 0)
            return BadRequest("it was not possible to generate the result");

            return Ok(moviesResult);
        }
    }
}