using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// ====== MODELS ======
public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
}

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    // Foreign key
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

// ====== DATABASE CONTEXT ======
public class RetailDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use SQLite DB
        optionsBuilder.UseSqlite("Data Source=retail.db");
    }
}

// ====== MAIN PROGRAM ======
class Program
{
    static void Main()
    {
        using var db = new RetailDbContext();
        db.Database.EnsureCreated(); // Creates the DB if it doesn't exist

        // Add sample data only if database is empty
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
            Console.WriteLine("✅ Sample data added.");
        }

        // Display inventory
        Console.WriteLine("\n📦 Inventory:");
        var products = db.Products.Include(p => p.Category).ToList();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} ({p.Category?.Name}) - {p.Quantity} units @ ₹{p.Price}");
        }
    }
}
