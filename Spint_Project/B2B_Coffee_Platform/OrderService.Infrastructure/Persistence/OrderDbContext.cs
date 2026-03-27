using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ─── Order Configuration ───────────────────────────────────────────
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Store the Enum as a string in the database so it's readable
                entity.Property(e => e.Status)
                      .HasConversion<string>()
                      .IsRequired()
                      .HasMaxLength(50);

                // SQL Server needs to know exactly how to store money (18 digits total, 2 decimals)
                entity.Property(e => e.TotalAmount)
                      .HasColumnType("decimal(18,2)");

                // Map the private '_items' list so EF Core knows how to fill the Order with its Items
                entity.Metadata.FindNavigation(nameof(Order.Items))!
                      .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            // ─── OrderItem Configuration ───────────────────────────────────────
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Sku).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(200);

                // Money precision again
                entity.Property(e => e.UnitPrice)
                      .HasColumnType("decimal(18,2)");

                // We tell SQL Server to IGNORE TotalPrice because C# calculates it on the fly!
                entity.Ignore(e => e.TotalPrice);
            });
        }
    }
}
