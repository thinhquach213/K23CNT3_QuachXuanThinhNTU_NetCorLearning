using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QxtLesson100.Models
{
    public partial class QxtK23lesson10DbContext : DbContext
    {
        // ✅ Chỉ giữ lại constructor có DbContextOptions
        public QxtK23lesson10DbContext(DbContextOptions<QxtK23lesson10DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId).HasName("PK__Category__27638D742CFB0A58");

                entity.ToTable("Category");

                entity.Property(e => e.CateId).HasColumnName("CateID");
                entity.Property(e => e.CateName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
