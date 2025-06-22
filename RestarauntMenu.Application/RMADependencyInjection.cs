using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService;
using System.Reflection;

namespace RestarauntMenu.Application
{
    public static class RMADependencyInjection
    {
        public static IServiceCollection AddRMADependencyInjection(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAccessAuthorizationChecker, AccessAuthorizationChecker>();
            return services;
        }
    }
}
