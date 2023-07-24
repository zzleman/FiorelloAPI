using System;
using Fiorello.Application.DTOs.AuthDTOs;
using FluentValidation;

namespace Fiorello.Application.Validators.AuthValidators;

public class RegisterDtoValidator: AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(U => U.Fullname)
            .MaximumLength(150);
        RuleFor(u => u.email)
            .EmailAddress()
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.username)
            .MaximumLength(90)
            .NotEmpty()
            .NotNull();
        RuleFor(u => u.password)
            .MaximumLength(150)
            .NotEmpty()
            .NotNull();

    }
}

