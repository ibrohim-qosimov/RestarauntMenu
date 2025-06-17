using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Infrastructure.Persistance;

namespace RestarauntMenu.Infrastructure;
public static class RMIDependencyInjection
{
    public static IServiceCollection AddRMIDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, RestarauntMenuDbContext>(ops =>
        {
            ops.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}