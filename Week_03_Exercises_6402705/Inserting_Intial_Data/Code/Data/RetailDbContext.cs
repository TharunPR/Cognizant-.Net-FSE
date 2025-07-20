using Microsoft.EntityFrameworkCore;
using RetailInventorySystem.Models;

namespace RetailInventorySystem.Data;

public class RetailDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=retail.db");
    }
}
