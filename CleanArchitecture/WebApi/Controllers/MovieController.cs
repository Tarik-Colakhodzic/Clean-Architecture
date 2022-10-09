using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieModel>>> GetAsync()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<List<MovieModel>>> GetByIdAsync(int id)
        {
            return Ok(await _movieService.GetByIdAsync(id));
        }
    }
}