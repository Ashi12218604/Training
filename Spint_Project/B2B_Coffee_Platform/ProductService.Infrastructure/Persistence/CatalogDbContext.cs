using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        // This DbSet represents the SQL table we will create
        public DbSet<CoffeeProduct> CoffeeProducts { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API: This enforces strict rules on our database table
            modelBuilder.Entity<CoffeeProduct>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Sku)
                      .IsRequired()
                      .HasMaxLength(50);

                // Ensure no two coffees have the same SKU
                entity.HasIndex(e => e.Sku)
                      .IsUnique();

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(300);

                // Enforce money formatting
                entity.Property(e => e.CartonPrice)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                // Global Query Filter: Automatically hide deactivated products from standard queries
                entity.HasQueryFilter(e => e.IsActive);
            });
        }
    }
}