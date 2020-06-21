using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DAL
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(
                    (hostBuilder, serviceCollection) => serviceCollection.AddDbContext<DataContext>((_, builder) =>
                        builder.UseSqlite(hostBuilder.Configuration.GetSection("ConnectionStrings")["SQLServerDB"])));
    }
}
