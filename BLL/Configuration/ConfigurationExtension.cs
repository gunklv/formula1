using BLL.Contracts.Services;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configuration
{
    //Would be better to collect through assemblies from API
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IFormula1Service, Formula1Service>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
