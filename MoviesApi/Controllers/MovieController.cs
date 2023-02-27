using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{


    private MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }


    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(item => item.Id == id);
        if (movie == null) { return NotFound(); }

        return Ok(movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _context.Movies.Skip(skip).Take(take);
    }
}
