using System.Text;
using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Infrastructure.Authentication;
using CustomDinner.Infrastructure.Persistence;
using CustomDinner.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CustomDinner.Infrastructure;

public static class 
    DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence();
        
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<CustomDinnerDbContext>(
            options => options.UseSqlServer("Server=localhost;Database=CustomDinner;User Id=sa;Password=L0c4l_D4t4b4s3!;TrustServerCertificate=true"));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
             
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        
        return services;
    }
}