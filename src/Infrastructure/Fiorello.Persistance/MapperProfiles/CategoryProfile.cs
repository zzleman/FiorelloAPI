using AutoMapper;
using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Domain.Entities;
using System.Reflection.Metadata;

namespace Fiorello.Persistance.MapperProfiles;

public class CategoryProfile:Profile
{
    public CategoryProfile() 
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }

}
