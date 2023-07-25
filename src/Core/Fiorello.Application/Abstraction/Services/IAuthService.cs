using System;
using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.DTOs.ResponseDTOs;

namespace Fiorello.Application.Abstraction.Services;

public interface IAuthService
{
    Task Register(RegisterDto registerDto);
    Task<TokenResponseDto> Login(SignInDto signInDto);
}

