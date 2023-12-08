namespace ProductManagementSystem.Core.Interfaces;

public interface IProductAddService
{
    /// <summary>
    /// Parses raw product data input and saves it into storage.
    /// </summary>
    /// <param name="fileName">Path to Excel file.</param>
    /// <returns></returns>
    Task AddProductsAsync(string fileName);
}
