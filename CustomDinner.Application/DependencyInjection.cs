using CustomDinner.Application.Authentication.Commands.Common;
using CustomDinner.Application.Authentication.Commands.Register;
using CustomDinner.Application.Common.Behaviors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CustomDinner.Application;

public static class InfrastructureDependencies 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(
                typeof(InfrastructureDependencies).Assembly));

        services.AddScoped<
            IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>,
            RegisterValidationBehavior>();
        
        return services;
    }
}