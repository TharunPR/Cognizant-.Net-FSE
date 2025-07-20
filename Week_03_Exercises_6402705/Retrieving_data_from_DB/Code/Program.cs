using Microsoft.EntityFrameworkCore;
using RetailInventorySystem.Data;
using RetailInventorySystem.Models;

using var db = new RetailDbContext();

// Create & seed database if needed
db.Database.EnsureCreated();

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

// Retrieve all products
var products = db.Products.Include(p => p.Category).ToList();

Console.WriteLine("=== All Products ===");
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - Category: {p.Category?.Name}, Quantity: {p.Quantity}, Price: ₹{p.Price}");
}

// Retrieve only Electronics
var electronicsOnly = db.Products
    .Include(p => p.Category)
    .Where(p => p.Category!.Name == "Electronics")
    .ToList();

Console.WriteLine("\n=== Electronics Only ===");
foreach (var p in electronicsOnly)
{
    Console.WriteLine($"{p.Name} - Qty: {p.Quantity}, Price: ₹{p.Price}");
}
