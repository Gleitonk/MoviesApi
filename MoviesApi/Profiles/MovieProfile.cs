using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class MovieProfile : AutoMapper.Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(
                movieDto => movieDto.Sessions,
                opt => opt.MapFrom(movie => movie.Sessions)
            );
        CreateMap<Movie, UpdateMovieDto>();
    }
}
