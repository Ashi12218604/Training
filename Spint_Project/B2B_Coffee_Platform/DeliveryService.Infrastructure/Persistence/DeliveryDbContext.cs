using DeliveryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Infrastructure.Persistence
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>().HasKey(d => d.Id);
            modelBuilder.Entity<Delivery>().HasIndex(d => d.OrderId).IsUnique();
            modelBuilder.Entity<Delivery>().HasIndex(d => d.TrackingNumber).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}