using AuthService.Domain.Entities;
using AuthService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Persistence
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(200);

                // No two users can share an email
                entity.HasIndex(e => e.Email)
                      .IsUnique();

                entity.Property(e => e.PasswordHash)
                      .IsRequired();

                // Store role as readable string in DB ("Superadmin", "Admin", "Client")
                entity.Property(e => e.Role)
                      .HasConversion<string>()
                      .HasMaxLength(50);
            });
        }
    }
}
