using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profile;

public class CinemaProfile : AutoMapper.Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(
                cinemaDto => cinemaDto.Address,
                opt => opt.MapFrom(cinema => cinema.Address)
            )
            .ForMember(
                cinemaDto => cinemaDto.Sessions,
                opt => opt.MapFrom(cinema => cinema.Sessions)
            );
        CreateMap<Cinema, UpdateCinemaDto>();
    }
}
