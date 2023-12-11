using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext dbContext;

    public ProductsRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddListAsync(IEnumerable<Product> products)
    {
        dbContext.Products.AddRange(products);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetNotGroupedAsync()
    {
        return await dbContext.Products.Where(p => !dbContext.GroupItems
            .Select(i => i.ProductId)
            .Contains(p.Id)
        ).ToListAsync();
    }
}
