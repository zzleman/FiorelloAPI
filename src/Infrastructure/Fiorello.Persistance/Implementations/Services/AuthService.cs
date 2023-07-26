using Fiorello.Application.DTOs.AuthDTOs;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Fiorello.Persistance.Exceptions;
using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Domain.Enums;

namespace Fiorello.Persistance.Implementations.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(UserManager<AppUser> userManager,
                       SignInManager<AppUser> signInManager,
                       RoleManager<IdentityRole> roleManager)
    {
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<TokenResponseDto> Login(SignInDto signInDto)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(signInDto.UsernameOrEmail);
        if (appUser is null)
        {
            appUser = await _userManager.FindByNameAsync(signInDto.UsernameOrEmail);
            if (appUser is null) throw new SignInFailedException("Invalid Login!!!");
        }

        SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, signInDto.password, true);
        if (!signInResult.Succeeded)
        {
            throw new SignInFailedException("Invalid login!!!");
        }
        return new TokenResponseDto("", DateTime.Now);
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
        var result = await _userManager.AddToRoleAsync(appUser, Role.Member.ToString());
        if (!result.Succeeded)
        {
            StringBuilder errorMessage = new();
            foreach (var error in result.Errors)
            {
                errorMessage.AppendLine(error.Description);
            }
            throw new RegistrationException(errorMessage.ToString());
        }
    }
}

