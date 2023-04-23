using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Application.Services.Authentication;
using CustomDinner.Infrastructure.Authentication;
using CustomDinner.Infrastructure.Persistence;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}