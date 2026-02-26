using Microsoft.EntityFrameworkCore;
using CollegeEFMVC.Models;

namespace CollegeEFMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollegeApplication>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<CollegeApplication>()
                .HasIndex(x => x.Phone)
                .IsUnique();
        }

        public DbSet<CollegeApplication> CollegeApplications { get; set; }
    }
}