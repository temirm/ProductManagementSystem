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

    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            IEnumerable<Guid> groups = await groupGeneratorService.GenerateGroupsAsync();
            logger.LogInformation($"{groups.Count()} groups were generated.");
        }
        catch (Exception ex)
        {
            throw new JobExecutionException(cause: ex);
        }        
    }
}
