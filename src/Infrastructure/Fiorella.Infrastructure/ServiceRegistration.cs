using Fiorella.Infrastructure.Services.Token;
using Fiorello.Application.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fiorella.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(IServiceCollection services)
    {
        services.AddScoped<ITokenHndler,TokenHandler>();
    }
}
