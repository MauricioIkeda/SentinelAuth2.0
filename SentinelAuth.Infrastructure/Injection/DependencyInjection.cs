using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentinelAuth.Application.Abstractions.Security;
using SentinelAuth.Infrastructure.Data;
using SentinelAuth.Infrastructure.Security;

namespace SentinelAuth.Infrastructure.Injection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            );
        });

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}