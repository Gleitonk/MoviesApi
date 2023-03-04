using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class SessionProfile : AutoMapper.Profile
{
    public SessionProfile()
    {
        CreateMap<Session, ReadSessionDto>();
        CreateMap<CreateSessionDto, Session>();
    }
}
