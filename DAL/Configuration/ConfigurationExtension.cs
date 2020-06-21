using BLL.Contracts.Repository;
using BLL.Domain;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DAL.Configuration
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            return services
                    .AddSingleton(context =>
                    {
                        var configuration = context.GetRequiredService<IConfiguration>();
                        //var loggerFactory = context.GetRequiredService<ILoggerFactory>();
                        var connection = configuration.GetSection("ConnectionStrings")["SQLServerDB"];

                        var options = new DbContextOptionsBuilder<DataContext>()
                                          //.UseLoggerFactory(loggerFactory)
                                          .UseSqlite(connection)
                                          .Options;

                        var initContext = new DataContext(options);
                        initContext.Database.EnsureCreated();
                        return options;
                    })
                    .AddTransient(context => new DataContext(context.GetRequiredService<DbContextOptions<DataContext>>()));
        }

        //Would be better to collect through assemblies from API
        public static IServiceCollection AddRepositores(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Formula1Team>, Repository<Formula1Team>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            return services;
        }
    }
}
