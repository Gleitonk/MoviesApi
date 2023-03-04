using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profile;

public class CinemaProfile : AutoMapper.Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<Cinema, UpdateCinemaDto>();
    }
}
