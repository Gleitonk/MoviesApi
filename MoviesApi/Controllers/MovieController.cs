using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Dtos;
using MoviesApi.Services;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;
    private readonly IMapper _mapper;

    public MovieController(MovieService movieService, IMapper mapper)
    {
        _movieService = movieService;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        var readDto = _movieService.AddMovie(movieDto);
        return CreatedAtAction(nameof(GetMovieById), new { id = readDto.Id }, readDto);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies(
        [FromQuery] string? cinemaName,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _movieService.GetMovies(skip, take, cinemaName);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movieDto = _movieService.GetMovieById(id);

        if (movieDto == null) return NotFound();

        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(
        Guid id,
        [FromBody] UpdateMovieDto movieDto
    )
    {
        var result = _movieService.UpdateMovie(id, movieDto);

        if (result.IsFailed) return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartial(
        Guid id,
        JsonPatchDocument<UpdateMovieDto> patch
    )
    {
        var movie = _movieService.GetMovieById(id);
        if (movie == null) return NotFound();

        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        var result = _movieService.UpdateMoviePartial(id, movieToUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(Guid id)
    {
        var result = _movieService.DeleteMovie(id);

        if (result.IsFailed) return NotFound();

        return NoContent();
    }
}
