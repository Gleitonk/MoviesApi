using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public class RegistrationService
{

    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly IMapper _mapper;

    public RegistrationService(UserManager<IdentityUser<Guid>> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public Result RegistrateUser(CreateUserDto createDto)
    {
        var userIdentity = _mapper.Map<IdentityUser<Guid>>(_mapper.Map<User>(createDto));

        var result = _userManager.CreateAsync(userIdentity, createDto.Password);
        if (result.Result.Succeeded) return Result.Ok();

        return Result.Fail("Registration Failed");
    }
}
