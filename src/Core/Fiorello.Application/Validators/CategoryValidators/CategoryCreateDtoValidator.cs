using Fiorello.Application.DTOs.CategoryDTOs;
using FluentValidation;

namespace Fiorello.Application.Validators.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty().MaximumLength(30)
            .Matches("^[a-zA-Z]+$").WithMessage("Name can only contain letters.");
        RuleFor(x => x.description).MaximumLength(500).Matches("^[a-zA-Z0-9]+$")
            .WithMessage("Description can only contain letters and digits(no symbols),");
    }
}

