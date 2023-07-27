using Microsoft.Extensions.DependencyInjection;
using Fiorello.Infrastructure.Services.Token;
using Fiorello.Application.Abstraction.Services;
namespace Fiorello.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices( this IServiceCollection services)
    {
        services.AddScoped<ITokenHndler, TokenHandler>();
    }
}
