using Microsoft.Extensions.Logging;
using ProductManagementSystem.Core.Interfaces;
using Quartz;

namespace ProductManagementSystem.TaskManager;

public class GenerateGroupsJob : IJob
{
    private readonly IGroupGeneratorService groupGeneratorService;
    private readonly ILogger<GenerateGroupsJob> logger;

    public GenerateGroupsJob(
        IGroupGeneratorService groupGeneratorService,
        ILogger<GenerateGroupsJob> logger)
    {
        this.groupGeneratorService = groupGeneratorService;
        this.logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        try
        {            
            logger.LogInformation("Success"); // TODO: Add actual job functionality
            
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new JobExecutionException(cause: ex);
        }        
    }
}
