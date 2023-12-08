namespace ProductManagementSystem.Core.Entities;

public class ProductStatus
{
    public Guid ProductId { get; private set; }
    public Guid? ProductGroupId { get; private set; }
    public bool IsInGroup { get; private set; } = false;

    public Product Product { get; private set; }

    public ProductStatus(Product product)
    {
        Product = product;
    }
}
