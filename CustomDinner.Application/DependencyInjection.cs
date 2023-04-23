using CustomDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Application;

public static class InfrastructureDependencies 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}