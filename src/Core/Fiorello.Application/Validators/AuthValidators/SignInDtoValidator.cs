using Fiorello.Application.DTOs.AuthDTOs;
using FluentValidation;

namespace Fiorello.Application.Validators.AuthValidators;

public class SignInDtoValidator:AbstractValidator<SignInDto>
{
    public SignInDtoValidator()
    {
        RuleFor(u => u.UsernameOrEmail)
            .MaximumLength(255)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.password)
            .MaximumLength(150)
            .NotEmpty()
            .NotNull();
    }
}
