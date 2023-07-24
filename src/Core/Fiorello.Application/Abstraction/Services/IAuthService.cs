using System;
using Fiorello.Application.DTOs.AuthDTOs;

namespace Fiorello.Application.Abstraction.Services;

public interface IAuthService
{
    Task Register(RegisterDto registerDto);
}

