using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// === Models ===
public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

// === DbContext ===
public class RetailDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using a local SQLite database file
        optionsBuilder.UseSqlite("Data Source=retail_simple.db");
    }
}

// === Program ===
class Program
{
    static void Main()
    {
        using var db = new RetailDbContext();
        db.Database.EnsureCreated(); // Create DB if not exists

        // Seed initial data
        if (!db.Categories.Any())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            db.Categories.AddRange(electronics, groceries);

            db.Products.AddRange(
                new Product { Name = "TV", Quantity = 5, Price = 30000, Category = electronics },
                new Product { Name = "Fan", Quantity = 10, Price = 1500, Category = electronics },
                new Product { Name = "Rice", Quantity = 50, Price = 60, Category = groceries }
            );

            db.SaveChanges();
            Console.WriteLine("✅ Sample data added.\n");
        }

        // Display products
        var products = db.Products.Include(p => p.Category).ToList();
        Console.WriteLine("📦 Inventory:");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} ({p.Category?.Name}) - {p.Quantity} units @ ₹{p.Price}");
        }
    }
}
