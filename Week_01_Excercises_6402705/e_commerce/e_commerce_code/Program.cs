public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class SearchService
{
    private List<Product> _products;

    public SearchService()
    {
        _products = new List<Product>
        {
            new() { Name = "Laptop", Price = 50000 },
            new() { Name = "Phone", Price = 20000 },
            new() { Name = "Tablet", Price = 15000 },
            new() { Name = "Smart Watch", Price = 8000 },
        };
    }

    public List<Product> Search(string keyword)
    {
        return _products
            .Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- E-commerce Product Search ---");
        var searchService = new SearchService();

        Console.Write("Enter search keyword: ");
        string input = Console.ReadLine();

        var results = searchService.Search(input);

        if (results.Count == 0)
        {
            Console.WriteLine("No products found.");
        }
        else
        {
            Console.WriteLine("Search Results:");
            foreach (var item in results)
            {
                Console.WriteLine($"- {item.Name} : ₹{item.Price:N0}");
            }
        }
    }
}
