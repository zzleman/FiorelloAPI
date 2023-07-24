using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Fiorello.Persistance.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task Register(RegisterDto registerDto)
    {
        AppUser appUser = new()
        {
            Fullname = registerDto.Fullname,
            UserName = registerDto.username,
            Email = registerDto.email,
            IsActive = true
        };
        IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerDto.password);

    }
}

