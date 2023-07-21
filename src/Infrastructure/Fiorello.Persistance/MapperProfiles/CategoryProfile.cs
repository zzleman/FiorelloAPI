using AutoMapper;
using System.Reflection.Metadata;

namespace Fiorello.Persistance.MapperProfiles;

public class CategoryProfile:Profile
{
    public CategoryProfile() 
    {
        CreateMap<User,UserViewModel>();
    }

}
