using EFTestMVC.Models;
using Microsoft.EntityFrameworkCore;
using EFTestMVC.Models;

namespace EFTestMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}