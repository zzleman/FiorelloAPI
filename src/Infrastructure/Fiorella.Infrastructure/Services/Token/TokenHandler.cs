﻿using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiorella.Infrastructure.Services.Token;

public class TokenHandler : ITokenHndler
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    public TokenHandler(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<TokenResponseDto> CreateAccessToken(int minutes, AppUser appUser)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier,appUser.Id),
            new Claim(ClaimTypes.Name,appUser.UserName)
        };

        var roles = await _userManager.GetRolesAsync(appUser);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        DateTime expireDate = DateTime.UtcNow.AddMinutes(minutes);
        JwtSecurityToken jwt = new(
            audience: _configuration["JWT:Audience"],
            issuer: _configuration["JWT:Issuer"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: credentials
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return new TokenResponseDto(token, expireDate);
    }
}