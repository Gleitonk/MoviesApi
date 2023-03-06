using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Requests;
using UsersApi.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{

    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }



    [HttpPost]
    public IActionResult LogInUser(LoginRequest request)
    {
        var result = _loginService.LogInUser(request);
        if (result.IsFailed) return Unauthorized(result.Errors);
        return Ok(result.Successes);
    }
}
