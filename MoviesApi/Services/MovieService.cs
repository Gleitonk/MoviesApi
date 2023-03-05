using AutoMapper;
using FluentResults;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Services;

public class MovieService
{

    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieService(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadMovieDto AddMovie(CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return _mapper.Map<ReadMovieDto>(movie);
    }

    public IEnumerable<ReadMovieDto> GetMovies(int skip, int take, string? cinemaName)
    {
        if (cinemaName != null)
        {
            return _mapper.Map<List<ReadMovieDto>>(
                     _context.Movies.ToList().Where(
                         movie => movie.Sessions.Any(session => session.Cinema.Name == cinemaName)));
        }

        return _mapper.Map<List<ReadMovieDto>>(
                    _context.Movies.Skip(skip).Take(take).ToList());
    }


    public ReadMovieDto? GetMovieById(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return null;

        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return movieDto;
    }

    public Result UpdateMovie(Guid id, object movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return Result.Fail("Movie Not Found");

        _mapper.Map(movieDto, movie);

        _context.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateMoviePartial(Guid id, UpdateMovieDto movieToUpdate)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeleteMovie(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return Result.Fail("Movie Not Found");

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return Result.Ok();
    }
}
