using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.GroupGeneratorAlgorithm;

public class PricedProductsDictionary
{
    private record PricedProductsDictionaryItem
    {
        public required Product Product { get; set; }
        public required int UnitsLeft { get; set; }
    }

    private readonly SortedDictionary<double, List<PricedProductsDictionaryItem>> dict = new();

    public bool IsEmpty => dict.Count == 0;

    public void InitializeWithProducts(IEnumerable<Product> products)
    {
        dict.Clear();

        foreach (var product in products)
        {
            if (dict.TryGetValue(product.UnitPrice, out List<PricedProductsDictionaryItem>? items))
            {
                items.Add(new() { Product = product, UnitsLeft = product.UnitNumber });                
            }
            else
            {
                items = new List<PricedProductsDictionaryItem>()
                {
                    new() { Product = product, UnitsLeft = product.UnitNumber }
                };
                dict.Add(product.UnitPrice, items);
            }
        }
    }

    public Product? PopMostExpensiveProductBelowPrice(double thresholdPrice)
    {
        foreach (double price in dict.Keys.Reverse())
        {
            if (price > thresholdPrice)
            {
                continue;
            }

            List<PricedProductsDictionaryItem> items = dict[price];
            PricedProductsDictionaryItem item = items.First();
            item.UnitsLeft--;

            if (item.UnitsLeft == 0)
            {
                items.Remove(item);

                if (items.Count == 0)
                {
                    dict.Remove(price);
                }
            }

            return item.Product;
        }

        return null;
    }
}
