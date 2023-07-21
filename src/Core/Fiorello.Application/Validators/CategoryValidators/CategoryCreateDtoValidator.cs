using Fiorello.Application.DTOs.CategoryDTOs;
using FluentValidation;

namespace Fiorello.Application.Validators.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.name).NotNull().NotEmpty().MaximumLength(30);
        RuleFor(x => x.description).MaximumLength(500);
    }
}

