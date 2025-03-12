using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtMVCAppCS.Models;

public partial class EmployeeManagementDbContext : DbContext
{
    private IConfiguration _EmpDBConfig { get; set; }
    public EmployeeManagementDbContext(IConfiguration configuration)
    {
        _EmpDBConfig = configuration;
    }

    public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _EmpDBConfig = configuration;
    }
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            _EmpDBConfig.GetConnectionString("EmpMgmtDBConnectionString")
    );
            
            //"Data Source=DESKTOP-G78QDQR;Initial Catalog=EmployeeManagementDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("EmpID");
            entity.Property(e => e.Age).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
