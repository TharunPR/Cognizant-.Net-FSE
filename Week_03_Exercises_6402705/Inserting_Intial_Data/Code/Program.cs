using Microsoft.EntityFrameworkCore;
using RetailInventorySystem.Data;
using RetailInventorySystem.Models;

using var db = new RetailDbContext();

// Apply migrations and create DB if not exists
db.Database.Migrate();

// Insert sample data if not exists
if (!db.Categories.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    db.Categories.AddRange(electronics, groceries);

    db.Products.AddRange(
        new Product { Name = "AC", Quantity = 10, Price = 40000, Category = electronics },
        new Product { Name = "Speaker", Quantity = 25, Price = 20000, Category = electronics },
        new Product { Name = "Greengram", Quantity = 100, Price = 250, Category = groceries }
    );

    db.SaveChanges();
}

// Display inventory
var products = db.Products.Include(p => p.Category).ToList();
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} ({p.Category?.Name}) - {p.Quantity} units @ ₹{p.Price}");
}
