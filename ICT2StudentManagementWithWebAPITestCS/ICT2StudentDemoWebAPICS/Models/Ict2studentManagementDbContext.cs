using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ICT2StudentDemoWebAPICS.Models;

public partial class Ict2studentManagementDbContext : DbContext
{
    private IConfiguration _configuration;
    public Ict2studentManagementDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Ict2studentManagementDbContext(
        DbContextOptions<Ict2studentManagementDbContext> options, 
        IConfiguration configuration): base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ICT2StudentManagementDB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.EnrollmentNo);

            entity.ToTable("Student");

            entity.Property(e => e.EnrollmentNo).ValueGeneratedNever();
            entity.Property(e => e.Achievement).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasMany(d => d.SubjectCodes).WithMany(p => p.EnrollmentNos)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudSub_Subject"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("EnrollmentNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudSub_Student"),
                    j =>
                    {
                        j.HasKey("EnrollmentNo", "SubjectCode").HasName("PK__StudentS__E69FA17A3B067215");
                        j.ToTable("StudentSubject");
                    });
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectCode).HasName("PK__Subject__9F7CE1A885ED02D1");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectCode).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
