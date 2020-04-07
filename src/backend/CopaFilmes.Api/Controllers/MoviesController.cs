using AutoMapper;
using CopaFilme.Business.Interfaces;
using CopaFilme.Business.Model;
using CopaFilmes.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet("obter-todos-filmes")]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Movies>>(_moviesService.GetMovies()));
        }

        [HttpPost("resultado-final")]
        public ActionResult GetFinishResult(List<MoviesViewModel> filmes)
        {
            return Ok(_moviesService.GetFinishResult(_mapper.Map<List<Movies>>(filmes)));
        }
    }
}