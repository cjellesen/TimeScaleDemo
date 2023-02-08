using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TimeScaleDbContext>(options => options
            .UseLazyLoadingProxies()
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                builder => builder.MigrationsAssembly(typeof(TimeScaleDbContext).Assembly.FullName)));
        
        services.AddScoped<ITimeScaleDbContext>(provider => provider.GetRequiredService<TimeScaleDbContext>());
        return services;
    }
}