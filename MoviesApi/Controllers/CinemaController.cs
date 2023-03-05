using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Dtos;
using MoviesApi.Services;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly CinemaService _cinemaService;
    private readonly IMapper _mapper;

    public CinemaController(CinemaService cinemaService, IMapper mapper)
    {
        _cinemaService = cinemaService;
        _mapper = mapper;
    }



    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var readDto = _cinemaService.AddCinema(cinemaDto);
        return CreatedAtAction(nameof(GetCinemaById), new { id = readDto.Id }, readDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas(
        [FromQuery] Guid? addressId,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _cinemaService.GetCinemas(skip, take, addressId);
    }


    [HttpGet("{id}")]
    public IActionResult GetCinemaById(Guid id)
    {
        var cinemaDto = _cinemaService.GetCinemaById(id);
        if (cinemaDto == null) return NotFound();
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(
        Guid id,
        [FromBody] UpdateCinemaDto cinemaDto
    )
    {
        var result = _cinemaService.UpdateCinema(id, cinemaDto);

        if (result.IsFailed) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(Guid id)
    {
        var result = _cinemaService.DeleteCinema(id);

        if (result.IsFailed) return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCinemaPartial(
        Guid id,
        [FromBody] JsonPatchDocument<UpdateCinemaDto> patch
    )
    {
        var cinema = _cinemaService.GetCinemaById(id);

        if (cinema == null) return NotFound();

        var cinemaToUpdate = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaToUpdate, ModelState);

        if (!TryValidateModel(cinemaToUpdate))
        {
            return ValidationProblem();
        }

        _cinemaService.UpdateCinemaPartial(id, cinemaToUpdate);
        return NoContent();
    }
}
