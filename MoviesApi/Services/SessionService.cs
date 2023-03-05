using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Services;

public class SessionService
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public SessionService(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadSessionDto CreateSession(CreateSessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return _mapper.Map<ReadSessionDto>(session);
    }

    public IEnumerable<ReadSessionDto> GetSessions(int skip, int take)
    {
        var sessions = _context.Sessions.Skip(skip).Take(take).ToList();
        return _mapper.Map<List<ReadSessionDto>>(sessions);
    }

    [HttpGet("{movieId}/{cinemaId}")]
    public ReadSessionDto? GetSessionById(Guid movieId, Guid cinemaId)
    {
        var session = _context.Sessions
            .FirstOrDefault(session => session.MovieId == movieId && session.CinemaId == cinemaId);

        if (session == null) return null;
        return _mapper.Map<ReadSessionDto>(session);
    }

    public Result UpdateSession(Guid movieId, Guid cinemaId, UpdateSessionDto sessionDto)
    {
        var session = _context.Sessions
              .FirstOrDefault(session => session.MovieId == movieId && session.CinemaId == cinemaId);
        if (session == null) return Result.Fail("Session Not Found");
        _mapper.Map(sessionDto, session);
        _context.SaveChanges();

        return Result.Ok();
    }

    public Result UpdateSessionPartial(Guid movieId, Guid cinemaId, UpdateSessionDto sessionToUpdate)
    {
        var session = _context.Sessions
              .FirstOrDefault(session => session.MovieId == movieId && session.CinemaId == cinemaId);

        _mapper.Map(sessionToUpdate, session);
        _context.SaveChanges();

        return Result.Ok();
    }

    public Result DeleteSession(Guid movieId, Guid cinemaId)
    {
        var session = _context.Sessions
              .FirstOrDefault(session => session.MovieId == movieId && session.CinemaId == cinemaId);

        if (session == null) return Result.Fail("Session Not Found");
        _context.Sessions.Remove(session);
        _context.SaveChanges();

        return Result.Ok();
    }
}
