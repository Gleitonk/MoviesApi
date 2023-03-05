using AutoMapper;
using FluentResults;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Services;

public class CinemaService
{

    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public CinemaService(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCinemaDto AddCinema(CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return _mapper.Map<ReadCinemaDto>(cinema);
    }

    public IEnumerable<ReadCinemaDto> GetCinemas(int skip, int take, Guid? addressId)
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

        return _mapper.Map<List<ReadCinemaDto>>(cinemas);
    }

    public ReadCinemaDto? GetCinemaById(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return null;

        return _mapper.Map<ReadCinemaDto>(cinema);
    }

    public Result UpdateCinema(Guid id, UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return Result.Fail("Cinema Not Found");

        var cinemaToUpdate = _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateCinemaPartial(
        Guid id,
        UpdateCinemaDto cinemaToUpdate
    )
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        _mapper.Map(cinemaToUpdate, cinema);
        _context.SaveChanges();

        return Result.Ok();
    }












    public Result DeleteCinema(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null) return Result.Fail("Cinema Not Found");

        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return Result.Ok();
    }
}
