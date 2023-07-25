using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Fiorello.Persistance.Exceptions;
using Fiorello.Application.DTOs.ResponseDTOs;

namespace Fiorello.Persistance.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public Task<TokenResponseDto> Login(SignInDto signInDto)
    {
        throw new NotImplementedException();
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
        if (!identityResult.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in identityResult.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }
    }
}

