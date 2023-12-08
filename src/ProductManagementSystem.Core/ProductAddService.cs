using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core;

public class ProductAddService : IProductAddService
{
    private readonly IExcelParser excelParser;
    private readonly IProductsRepository productsRepository;

    public ProductAddService(IExcelParser excelParser, IProductsRepository productsRepository)
    {
        this.excelParser = excelParser;
        this.productsRepository = productsRepository;
    }

    public async Task AddProductsAsync(string fileName)
    {
        IEnumerable<Product> products = excelParser.ParseProductData(fileName);
        await productsRepository.AddListAsync(products);
    }
}
