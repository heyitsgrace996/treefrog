using Microsoft.EntityFrameworkCore;
using Treefrog.Models;
using System.IO;
using Treefrog.Models.Database;
using MenuItem = Microsoft.Maui.Controls.MenuItem;
using Microsoft.Extensions.Logging;

namespace Treefrog.Data;

public class OrderHistoryContext : DbContext
{
    public DbSet<DbOrder> Orders { get; set; }
    public DbSet<DbOrderItem> OrderItems { get; set; }

    public OrderHistoryContext(DbContextOptions<OrderHistoryContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "coffeeshop.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        // Optional: Configure logging to the console
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships if needed
        modelBuilder.Entity<DbOrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId);

        base.OnModelCreating(modelBuilder);
    }
}
