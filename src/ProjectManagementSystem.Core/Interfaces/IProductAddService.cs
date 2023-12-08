namespace ProductManagementSystem.Core.Interfaces;

public interface IProductAddService
{
    /// <summary>
    /// Parses raw product data input and saves it into storage.
    /// </summary>
    /// <returns></returns>
    Task AddProductsAsync();
}
