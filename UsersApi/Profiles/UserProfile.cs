using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.Profiles;

public class UserProfile : AutoMapper.Profile
{

    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, IdentityUser<Guid>>();
    }
}
