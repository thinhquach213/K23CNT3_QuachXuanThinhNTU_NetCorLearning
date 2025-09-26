using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuachXuanThinh_2310900100_de05.Models;

public partial class QuachXuanThinh2310900100De05Context : DbContext
{
    public QuachXuanThinh2310900100De05Context()
    {
    }

    public QuachXuanThinh2310900100De05Context(DbContextOptions<QuachXuanThinh2310900100De05Context> options)
        : base(options)
    {
    }

    public virtual DbSet<QxtTask> QxtTasks { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=QuachXuanThinh_2310900100_de05;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QxtTask>(entity =>
        {
            entity.HasKey(e => e.QxtTaskId).HasName("PK__QxtTask__8B2A74CBFC4AB1CB");

            entity.ToTable("QxtTask");

            entity.Property(e => e.QxtStartDate).HasColumnType("datetime");
            entity.Property(e => e.QxtTaskName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
