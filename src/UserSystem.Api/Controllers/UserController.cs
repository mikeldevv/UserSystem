using Microsoft.AspNetCore.Mvc;
using UserSystem.Api.Dtos;
using UserSystem.Contracts;

namespace UserSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserRequestDto registerUserRequestDto)
    {
        await _userService.CreateUser(
            registerUserRequestDto.FirstName,
            registerUserRequestDto.EmailAddress);

        return new StatusCodeResult(StatusCodes.Status201Created);
    }
}