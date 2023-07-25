using System;
namespace Fiorello.Application.DTOs.AuthDTOs;


public record RegisterDto(string? Fullname, string username, string email, string password);