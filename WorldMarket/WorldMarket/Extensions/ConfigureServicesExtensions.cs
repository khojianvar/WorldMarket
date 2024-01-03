using Microsoft.EntityFrameworkCore;
using WorldMarket.Infrastructure.Persistence;

namespace WorldMarket.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<WorldMarketDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WorldMarketConection")));

            return services;
        }
    }
}
