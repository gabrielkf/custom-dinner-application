using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Infrastructure.Authentication;

using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}