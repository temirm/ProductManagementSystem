using Microsoft.Extensions.DependencyInjection;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IProductAddService, ProductAddService>();
        services.AddScoped<IGroupsService, GroupsService>();
        services.AddScoped<IGroupGeneratorService, GroupGeneratorService>();
        services.AddSingleton<IGroupGeneratorAlgorithm, GroupGeneratorAlgorithm.GroupGeneratorAlgorithm>();

        return services;
    }
}
