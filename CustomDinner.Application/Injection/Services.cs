using System.Runtime.ExceptionServices;

using CustomDinner.Application.Services.Authentication;

using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Application.Injection;

public static class InfrastructureDependencies 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}