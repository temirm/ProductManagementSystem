using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Infrastructure.Repositories;

public class GroupsRepository : IGroupsRepository
{
    private readonly AppDbContext dbContext;

    public GroupsRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddListAsync(IEnumerable<ProductGroup> groups)
    {
        dbContext.Groups.AddRange(groups);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ProductGroup?> GetById(Guid id)
        => await dbContext.Groups.FirstOrDefaultAsync(g => g.Id == id);

    public async Task<IEnumerable<ProductGroup>> ListAll()
        => await dbContext.Groups.ToListAsync();
}
