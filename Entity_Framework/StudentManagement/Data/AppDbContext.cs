using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System.Reflection.Emit;

namespace StudentManagement.Data
{
  
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Marks> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasMany(s => s.Marks)
            .WithOne(m => m.Student)
            .HasForeignKey(m => m.StudentId);
        }
    }
}
