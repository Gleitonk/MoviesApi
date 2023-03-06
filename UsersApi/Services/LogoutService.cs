using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsersApi.Services;

public class LogoutService
{

    private readonly SignInManager<IdentityUser<Guid>> _signInManager;

    public LogoutService(SignInManager<IdentityUser<Guid>> signInManager)
    {
        _signInManager = signInManager;
    }

    public Result LogoutUser()
    {
        var resultIdentity = _signInManager.SignOutAsync();
        if (resultIdentity.IsCompletedSuccessfully) return Result.Ok();

        return Result.Fail("Logout Failed");
    }
}
