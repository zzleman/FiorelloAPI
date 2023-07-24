using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistance.Implementations.Services;

public class AuthService : IAuthService
{
    public Task Register(RegisterDto registerDto)
    {
        AppUser appUser = new()
        {
            Fullname = registerDto.Fullname,
            UserName = registerDto.username,
            Email = registerDto.email,
            IsActive = true
        };
    }
}

