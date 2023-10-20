using System;
using System.Collections.Generic;
using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoMVC.Data
{
    public partial class QLSACHContext : DbContext
    {
        public QLSACHContext()
        {
        }

        public QLSACHContext(DbContextOptions<QLSACHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sach> Saches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QLSACH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__SACH__3FC48E4CE107A9B6");

                entity.ToTable("SACH");

                entity.Property(e => e.Masach)
                    .ValueGeneratedNever()
                    .HasColumnName("MASACH");

                entity.Property(e => e.Anhbia)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ANHBIA");

                entity.Property(e => e.Mota)
                    .HasMaxLength(500)
                    .HasColumnName("MOTA");

                entity.Property(e => e.Namxb).HasColumnName("NAMXB");

                entity.Property(e => e.Ngonngu)
                    .HasMaxLength(50)
                    .HasColumnName("NGONNGU");

                entity.Property(e => e.Nxb)
                    .HasMaxLength(100)
                    .HasColumnName("NXB");

                entity.Property(e => e.Sotrang).HasColumnName("SOTRANG");

                entity.Property(e => e.Tacgia)
                    .HasMaxLength(100)
                    .HasColumnName("TACGIA");

                entity.Property(e => e.Tensach)
                    .HasMaxLength(100)
                    .HasColumnName("TENSACH");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
