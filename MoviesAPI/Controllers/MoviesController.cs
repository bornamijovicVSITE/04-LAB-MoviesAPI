using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Services;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MoviesService _moviesService;
        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = _moviesService.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _moviesService.GetMovieById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieById(int id, [FromBody] MovieVM movieVm)
        {
            var updated = _moviesService.UpdateMovie(id, movieVm);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var deleted = _moviesService.DeleteMovie(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}



