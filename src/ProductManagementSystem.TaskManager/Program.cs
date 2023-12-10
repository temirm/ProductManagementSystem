using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductManagementSystem.Core;
using ProductManagementSystem.Core.GroupGeneratorAlgorithm;
using ProductManagementSystem.Core.Interfaces;
using ProductManagementSystem.Infrastructure.Repositories;
using Quartz;

namespace ProductManagementSystem.TaskManager;

public class Program
{
    public static async Task Main()
    {
        await CreateHostBuilder().Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddQuartz(q =>
                {
                    q.ScheduleJob<GenerateGroupsJob>(trigger => trigger
                        // TODO: Change configuration
                        .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow.AddSeconds(5)))
                        .WithDailyTimeIntervalSchedule(x => x.WithInterval(5, IntervalUnit.Second))
                    );
                });

                services.AddQuartzHostedService(options =>
                {
                    options.WaitForJobsToComplete = true;
                });

                services.AddTransient<GenerateGroupsJob>();
                services.AddTransient<IGroupGeneratorService, GroupGeneratorService>();
                services.AddSingleton<IGroupGeneratorAlgorithm, GroupGeneratorAlgorithm>();
                services.AddTransient<IProductsRepository, ProductsRepository>();
                services.AddTransient<IGroupsRepository, GroupsRepository>();
            });
}
