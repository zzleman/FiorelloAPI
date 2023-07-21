using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Domain.Entities;
using Fiorello.Persistance.Exceptions;

namespace Fiorello.Persistance.Implementations.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _readRepository;

    private readonly ICategoryWriteRepository _writeRepository;

    public CategoryService(ICategoryReadRepository readRepository,
                           ICategoryWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        Category? dbCategory = await _readRepository
       .GetByExpressionAsync(c => c.Name.ToLower().Equals(categoryCreateDto.name.ToLower()));
        if (dbCategory is not null) throw new DuplicatedException("Dupliacted category name!!");
        
    }

    public Task<List<CategoryGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryGetDto> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}

