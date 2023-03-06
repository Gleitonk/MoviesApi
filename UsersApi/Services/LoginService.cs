using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Requests;

namespace UsersApi.Services;

public class LoginService
{

    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly TokenService _tokenService;

    public LoginService(SignInManager<IdentityUser<Guid>> signInManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public Result LogInUser(LoginRequest request)
    {
        var resultIdentity = _signInManager
                            .PasswordSignInAsync(request.UserName, request.Password, false, false);

        if (resultIdentity.Result.Succeeded)
        {
            var identityUser = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedUserName == request.UserName.ToUpper());

            var token = _tokenService.CreateToken(identityUser);

            return Result.Ok().WithSuccess(token.Value);
        }

        return Result.Fail("Login Failed");
    }
}