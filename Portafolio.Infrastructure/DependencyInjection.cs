using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portafolio.Application.Abstractions.Database;
using Portafolio.Infrastructure.Database;

namespace Portafolio.Infrastructure;

public static class DependencyInjection
{
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("connection_string");
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbContext()
                .AddHealthChecksConfiguration();
    }

    private static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }
    
    private static void AddHealthChecksConfiguration(this IServiceCollection services)
    {
        services.AddHealthChecks()
                .AddSqlServer(ConnectionString)
                .AddDbContextCheck<ApplicationDbContext>();
    }
}