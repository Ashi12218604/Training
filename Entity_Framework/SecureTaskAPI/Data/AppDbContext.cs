using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}