using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas(
        [FromQuery] Guid? addressId,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        var cinemas = new List<Cinema>();
        if (addressId != null)
        {
            cinemas = _context.Cinemas.Where(cinema => cinema.AddressId == addressId).ToList();
        }
        else
        {
            cinemas = _context.Cinemas.Skip(skip).Take(take).ToList();
        }

        var cinemasDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
        return cinemasDto;
    }


    [HttpGet("{id}")]
    public IActionResult GetCinemaById(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return NotFound();

        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(
        Guid id,
        [FromBody] UpdateCinemaDto cinemaDto
    )
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return NotFound();

        var cinemaToUpdate = _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return NotFound();

        _context.Cinemas.Remove(cinema);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCinemaPartial(
        Guid id,
        [FromBody] JsonPatchDocument<UpdateCinemaDto> patch
    )
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return NotFound();

        var cinemaToUpdate = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaToUpdate, ModelState);

        if (!TryValidateModel(cinemaToUpdate))
        {
            return ValidationProblem();
        }

        _mapper.Map(cinemaToUpdate, cinema);
        _context.SaveChanges();

        return NoContent();
    }
}
