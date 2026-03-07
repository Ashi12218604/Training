using Microsoft.EntityFrameworkCore;
using MVCRepo.Models;
using System.Reflection.Emit;
namespace MVCRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("TblStudentMaster");
        }
    }
}
