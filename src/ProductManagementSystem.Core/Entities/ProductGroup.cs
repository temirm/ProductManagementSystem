namespace ProductManagementSystem.Core.Entities;

public class ProductGroup
{
    public Guid Id { get; set; }

    private List<ProductGroupItem> items = new();
    public IEnumerable<ProductGroupItem> GroupItems => items.ToArray();

    public void AddGroupItem(ProductGroupItem item)
    {
        items.Add(item);
    }

    public double TotalPrice => items.Select(i => i.UnitNumber * i.Product.UnitPrice).Sum();
}
