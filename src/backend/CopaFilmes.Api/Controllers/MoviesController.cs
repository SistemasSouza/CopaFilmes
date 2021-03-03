using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CopaFilmes.Api.Models;
using CopaFilmes.Api.Services;

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
        public ActionResult GetAll()
        {
            return Ok(_moviesService.GetMovies());
        }

        [HttpPost("resultado-final")]
        public ActionResult GetFinishResult(List<Movies> movies)
        {
            return Ok(_moviesService.GetFinishResult(movies));
        }
    }
}