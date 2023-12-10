using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductGroup> Groups { get; set; }
    public DbSet<ProductGroupItem> GroupItems { get; set; }

    public string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "sqlite.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany<ProductGroup>()
            .WithMany()
            .UsingEntity<ProductGroupItem>();
    }
}
