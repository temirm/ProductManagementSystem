using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces;

namespace ProjectManagementSystem.Core;

public class ProductAddService : IProductAddService
{
    private readonly IExcelParser excelParser;
    private readonly IProductsRepository productsRepository;

    public ProductAddService(IExcelParser excelParser, IProductsRepository productsRepository)
    {
        this.excelParser = excelParser;
        this.productsRepository = productsRepository;
    }

    public async Task AddProductsAsync()
    {
        IEnumerable<Product> products = excelParser.ParseProductData();
        await productsRepository.AddListAsync(products);
    }
}
