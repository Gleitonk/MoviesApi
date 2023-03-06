using Microsoft.AspNetCore.Mvc;
using UsersApi.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogoutController : ControllerBase
{
    private readonly LogoutService _logoutService;


public LogoutController(LogoutService logoutService)
    {
        _logoutService = logoutService;
    }

    [HttpPost]

    public IActionResult LogoutUser()
    {
        var result = _logoutService.LogoutUser();
        if (result.IsFailed) return Unauthorized(result.Errors);
        return Ok(result.Successes);
    }

}
