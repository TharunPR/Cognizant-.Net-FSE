using Microsoft.EntityFrameworkCore;
using RetailInventorySystem.Models;

namespace RetailInventorySystem.Data;

public class RetailDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=retail.db");
    }
}
