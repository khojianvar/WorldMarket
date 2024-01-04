using Microsoft.EntityFrameworkCore;
using WorldMarket.Domain.Interfaces.Repositories;
using WorldMarket.Domain.Interfaces.Services;
using WorldMarket.Infrastructure.Persistence;
using WorldMarket.Infrastructure.Persistence.Repositories;
using WorldMarket.Services;

namespace WorldMarket.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<ISupplyItemRepository, SupplyItemRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleItemService, SaleItemService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISupplyService, SupplyService>();
            services.AddScoped<ISupplyItemService, SupplyItemService>();

            return services;
        }
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            services.AddDbContext<WorldMarketDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WorldMarketConection")));

            return services;
        }
    }
}
