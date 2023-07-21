using AutoMapper;
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
    private readonly IMapper _mapper;

    public CategoryService(ICategoryReadRepository readRepository,
                           ICategoryWriteRepository writeRepository,
                           IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        Category? dbCategory = await _readRepository
       .GetByExpressionAsync(c => c.Name.ToLower().Equals(categoryCreateDto.name.ToLower()));
        if (dbCategory is not null) throw new DuplicatedException("Dupliacted category name!!");
        Category newCategory=_mapper.Map<Category>(categoryCreateDto);
        await _writeRepository.AddAsync(newCategory);
        await _writeRepository.SaveChangeAsync();
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

