using System.Reflection;
using CustomDinner.Api.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CustomDinner.Api;

public static class InfrastructureDependencies 
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMapping();
        
        return services;
    }
    
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddSingleton<IMapper, ServiceMapper>();

        return services;
    }
}
