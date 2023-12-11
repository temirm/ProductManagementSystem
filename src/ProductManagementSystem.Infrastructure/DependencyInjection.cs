using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Core.Interfaces;
using ProductManagementSystem.Infrastructure.Repositories;

namespace ProductManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddExcelParser(this IServiceCollection services)
        => services.AddTransient<IExcelParser, ExcelParser>();

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(ServiceLifetime.Singleton);
        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddTransient<IGroupsRepository, GroupsRepository>();
        
        return services;
    }
}
