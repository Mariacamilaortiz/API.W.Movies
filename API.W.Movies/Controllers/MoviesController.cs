using API.W.Movies.DAL.Models.Dtos;
using API.W.Movies.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.W.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _service.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            try
            {
                return Ok(await _service.GetMovieAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync(MovieCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var movie = await _service.CreateMovieAsync(dto);
                return CreatedAtAction(nameof(GetMovieAsync), new { id = movie.Id }, movie);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.UpdateMovieAsync(dto, id));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("No se encontró"))
            {
                return NotFound(new { ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                return Ok(await _service.DeleteMovieAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { ex.Message });
            }
        }
    }
}
