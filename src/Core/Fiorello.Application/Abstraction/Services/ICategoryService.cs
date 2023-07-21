using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Services;

public interface ICategoryService
{
    Task CreateAsync(CategoryCreateDto categoryCreateDto);

    Task<CategoryGetDto> GetByIdAsync(Guid Id);

    Task<List<CategoryGetDto>> GetAllAsync();
}

