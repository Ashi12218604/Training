using Microsoft.EntityFrameworkCore;
using StudentMarksAPI.Models;

namespace StudentMarksAPI.Data
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}