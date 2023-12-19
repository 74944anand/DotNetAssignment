using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Models;

public partial class EmpDataContext : DbContext
{
    public EmpDataContext()
    {
    }

    public EmpDataContext(DbContextOptions<EmpDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=EmpData;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Table__7AD04F11638EB339");

            entity.ToTable("Table");

            entity.Property(e => e.EmployeeCity)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EmployeeDob)
                .HasColumnType("date")
                .HasColumnName("EmployeeDOB");
            entity.Property(e => e.EmployeeGender).HasMaxLength(10);
            entity.Property(e => e.EmployeeName).HasMaxLength(20);
            entity.Property(e => e.EmployeeSalary).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
