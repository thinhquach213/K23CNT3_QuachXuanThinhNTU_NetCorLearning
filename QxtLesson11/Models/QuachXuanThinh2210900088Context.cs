using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QxtLesson11.Models;

public partial class QuachXuanThinh2210900088Context : DbContext
{
    public QuachXuanThinh2210900088Context()
    {
    }

    public QuachXuanThinh2210900088Context(DbContextOptions<QuachXuanThinh2210900088Context> options)
        : base(options)
    {
    }

    public virtual DbSet<QxtEmployee> QxtEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=QuachXuanThinh_2210900088;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QxtEmployee>(entity =>
        {
            entity.HasKey(e => e.QxtEmpId).HasName("PK__QxtEmplo__BEB96FA7C621F883");

            entity.ToTable("QxtEmployee");

            entity.Property(e => e.QxtEmpId).HasColumnName("qxtEmpId");
            entity.Property(e => e.QxtEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("qxtEmpLevel");
            entity.Property(e => e.QxtEmpName)
                .HasMaxLength(100)
                .HasColumnName("qxtEmpName");
            entity.Property(e => e.QxtEmpStartDate).HasColumnName("qxtEmpStartDate");
            entity.Property(e => e.QxtEmpStatus).HasColumnName("qxtEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
