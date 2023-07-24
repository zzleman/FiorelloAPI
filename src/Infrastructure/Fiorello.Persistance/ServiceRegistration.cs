using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.Validators.CategoryValidators;
using Fiorello.Persistance.Contexts;
using Fiorello.Persistance.Helpers;
using Fiorello.Persistance.Implementations.Repositories;
using Fiorello.Persistance.Implementations.Services;
using Fiorello.Persistance.MapperProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiorello.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(Configuration.ConnectionString);
        });

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();
        services.AddAutoMapper(typeof(CategoryProfile).Assembly);

        services.AddReadRepositories();
        services.AddWriteRepositories();

        services.AddScoped<ICategoryService, CategoryService>();
    }

    private static void AddReadRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
    }

    private static void AddWriteRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
    }
}
