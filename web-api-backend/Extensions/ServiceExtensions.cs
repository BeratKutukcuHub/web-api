using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contract;
using Repositories.EfCore;
using Services;
using Services.Contract;
using Services.EfCore;

namespace Backend.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContextExtension(this IServiceCollection services,
     IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
        });

    public static void AllRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductManager<Product>, ProductManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }
    public static void LoggerService(this IServiceCollection service)
    {
        service.AddSingleton<ILoggerService, LoggerService>();
    }
    
}