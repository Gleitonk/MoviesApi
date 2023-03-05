using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Dtos;
using MoviesApi.Services;

namespace MoviesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{

    private readonly SessionService _sessionService;
    private readonly IMapper _mapper;

    public SessionController(SessionService sessionService, IMapper mapper)
    {
        _sessionService = sessionService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateSession([FromBody] CreateSessionDto sessionDto)
    {
        var readDto = _sessionService.CreateSession(sessionDto);

        return CreatedAtAction(
                    nameof(GetSessionById),
                    new { cinemaId = readDto.CinemaId, movieId = readDto.MovieId },
                    readDto
                );
    }



    [HttpGet]
    public IEnumerable<ReadSessionDto> GetSessions(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _sessionService.GetSessions(skip, take);
    }

    [HttpGet("{movieId}/{cinemaId}")]
    public IActionResult GetSessionById(
        Guid movieId,
        Guid cinemaId
    )
    {
        var sessionDto = _sessionService.GetSessionById(movieId, cinemaId);

        if (sessionDto == null) return NotFound();
        return Ok(sessionDto);
    }

    [HttpPut("{movieId}/{cinemaId}")]
    public IActionResult UpdateSession(
        Guid movieId,
        Guid cinemaId,
       [FromBody] UpdateSessionDto sessionDto
    )
    {
        var result = _sessionService.UpdateSession(movieId, cinemaId, sessionDto);
        if (result.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpPatch("{movieId}/{cinemaId}")]
    public IActionResult UpdateSessionPartial(
        Guid movieId,
        Guid cinemaId,
        JsonPatchDocument<UpdateSessionDto> patch
    )
    {
        var session = _sessionService.GetSessionById(movieId, cinemaId);
        if (session == null) return NotFound();

        var sessionToUpdate = _mapper.Map<UpdateSessionDto>(session);

        patch.ApplyTo(sessionToUpdate, ModelState);

        if (!TryValidateModel(sessionToUpdate))
        {
            return ValidationProblem();
        }
        _sessionService.UpdateSessionPartial(movieId, cinemaId, sessionToUpdate);
        return NoContent();
    }

    [HttpDelete("{movieId}/{cinemaId}")]
    public IActionResult DeleteSession(
        Guid movieId,
        Guid cinemaId
    )
    {
        var result = _sessionService.DeleteSession(movieId, cinemaId);
        if (result.IsFailed) return NotFound();
        return NoContent();
    }
}
