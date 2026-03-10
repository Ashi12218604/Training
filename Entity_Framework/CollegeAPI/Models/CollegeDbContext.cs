using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Models;

public partial class CollegeDbContext : DbContext
{
    public CollegeDbContext()
    {
    }

    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<StudentsT> StudentsTs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId);

            entity.HasIndex(e => e.StudentId).IsUnique();

            entity.HasOne(d => d.Student)
                .WithOne(p => p.Hostel)
                .HasForeignKey<Hostel>(d => d.StudentId);
        });

        modelBuilder.Entity<StudentsT>(entity =>
        {
            entity.HasKey(e => e.StudentIdNum);

            entity.ToTable("StudentsT");

            entity.Property(e => e.Name)
                .HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}