using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="movieDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie(
        [FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }


    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(item => item.Id == id);
        if (movie == null) { return NotFound(); }

        var movieDto = _mapper.Map<GetMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpGet]
    public IEnumerable<GetMovieDto> GetMovies(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _mapper.Map<List<GetMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(
        int id,
        [FromBody] UpdateMovieDto movieDto
    )
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) { return NotFound(); }

        _mapper.Map(movieDto, movie);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartial(
        int id,
        JsonPatchDocument<UpdateMovieDto> patch
    )
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) { return NotFound(); }

        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieToUpdate, ModelState);

        if (!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {

        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) { return NotFound(); }

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }

}
