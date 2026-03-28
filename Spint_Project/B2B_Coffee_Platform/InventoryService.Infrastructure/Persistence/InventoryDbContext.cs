using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>().HasKey(i => i.Id);
            modelBuilder.Entity<InventoryItem>().HasIndex(i => i.ProductId).IsUnique(); // One inventory record per product!
            base.OnModelCreating(modelBuilder);
        }
    }
}