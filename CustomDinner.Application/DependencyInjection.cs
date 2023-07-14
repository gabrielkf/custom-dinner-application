using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Application;

public static class InfrastructureDependencies 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(InfrastructureDependencies).Assembly));
        
        return services;
    }
}