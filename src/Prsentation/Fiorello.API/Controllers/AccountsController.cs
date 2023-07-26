using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AccountsController : ControllerBase
{
    private readonly IAuthService _authService;

    public AccountsController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("action")]

    public async Task<IActionResult> Login(SignInDto signInDto)
    {
        var response = await _authService.Login(signInDto);
        return Ok(response);
    }
}

