using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class Qxtk23cnttLesson12Context : DbContext
{
    public Qxtk23cnttLesson12Context()
    {
    }

    public Qxtk23cnttLesson12Context(DbContextOptions<Qxtk23cnttLesson12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<QxtPost> QxtPosts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=qxtk23cntt_Lesson12;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QxtPost>(entity =>
        {
            entity.HasKey(e => e.QxtId).HasName("PK__QxtPost__2EC379AA281162EC");

            entity.ToTable("QxtPost");

            entity.Property(e => e.QxtId).HasColumnName("QxtID");
            entity.Property(e => e.QxtImage).HasMaxLength(255);
            entity.Property(e => e.QxtTitle).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
