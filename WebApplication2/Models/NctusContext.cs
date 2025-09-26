using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class NctusContext : DbContext
{
    public NctusContext()
    {
    }

    public NctusContext(DbContextOptions<NctusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ctu> Ctus { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=Nctus;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ctu>(entity =>
        {
            entity.HasKey(e => e.CtuId).HasName("PK__ctus__269DEBB931765F9D");

            entity.ToTable("ctus");

            entity.Property(e => e.CtuImage).HasMaxLength(255);
            entity.Property(e => e.CtuTitle).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
