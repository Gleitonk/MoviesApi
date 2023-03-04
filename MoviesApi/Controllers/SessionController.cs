using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{

    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    //[HttpPost]
    //public IActionResult CreateSession(
    //  [FromBody] CreateSessionDto sessionDto
    //)
    //{
    //    var session = _mapper.Map<Session>(sessionDto);
    //    _context.Sessions.Add(session);
    //    _context.SaveChanges();
    //    return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
    //}



    //[HttpGet]
    //public IEnumerable<ReadSessionDto> GetSessions(
    //[FromQuery] int skip = 0,
    //[FromQuery] int take = 50
    //)
    //{
    //    var sessions = _context.Sessions.Skip(skip).Take(take).ToList();

    //    return _mapper.Map<List<ReadSessionDto>>(sessions);
    //}

    //[HttpGet("{id}")]
    //public IActionResult GetSessionById(
    //    Guid id
    //)
    //{
    //    var session = _context.Sessions.FirstOrDefault(session => session.Id == id);

    //    if (session == null) return NotFound();
    //    return Ok(_mapper.Map<ReadSessionDto>(session));
    //}

    //[HttpPut("{id}")]
    //public IActionResult UpdateSession(
    //   Guid id,
    //   [FromBody] UpdateSessionDto sessionDto
    //)
    //{
    //    var session = _context.Sessions.FirstOrDefault(session => session.Id == id);
    //    if (session == null) return NotFound();

    //    _mapper.Map(sessionDto, session);
    //    _context.SaveChanges();

    //    return NoContent();
    //}

    //[HttpPatch("{id}")]
    //public IActionResult UpdateSessionPartial(
    //    Guid id,
    //    JsonPatchDocument<UpdateSessionDto> patch
    //)
    //{
    //    var session = _context.Sessions.FirstOrDefault(session => session.Id == id);
    //    if (session == null) return NotFound();

    //    var sessionToUpdate = _mapper.Map<UpdateSessionDto>(session);

    //    patch.ApplyTo(sessionToUpdate, ModelState);

    //    if (!TryValidateModel(sessionToUpdate))
    //    {
    //        return ValidationProblem();
    //    }

    //    _mapper.Map(sessionToUpdate, session);
    //    _context.SaveChanges();

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public IActionResult DeleteSession(
    //    Guid id
    //)
    //{
    //    var session = _context.Sessions.FirstOrDefault(session => session.Id == id);

    //    if (session == null) return NotFound();
    //    _context.Sessions.Remove(session);
    //    _context.SaveChanges();

    //    return NoContent();
    //}
}
