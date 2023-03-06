using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Services;

namespace UsersApi.Controllers;


[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly RegistrationService _userRegistrationService;

    public RegistrationController(RegistrationService userRegistrationService)
    {
        _userRegistrationService = userRegistrationService;
    }


    [HttpPost]
    public IActionResult RegistrateUser(CreateUserDto createDto)
    {
        var result = _userRegistrationService.RegistrateUser(createDto);
        if (result.IsFailed) return StatusCode(500);
        return Ok();
    }
}
