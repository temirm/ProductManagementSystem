namespace ProjectManagementSystem.Core.Entities;

public class ProductGroup
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int UnitNumber { get; private set; }

    public Product Product { get; private set; }

    public ProductGroup(Product product)
    {
        Product = product;
    }
}
