using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MicroCartApi.Models
{
    public partial class sampleshoppingdbContext : DbContext
    {
        public sampleshoppingdbContext()
        {
        }

        public sampleshoppingdbContext(DbContextOptions<sampleshoppingdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=sampleshoppingdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Deliverydate)
                    .HasColumnType("datetime")
                    .HasColumnName("deliverydate");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Productorderdate)
                    .HasColumnType("datetime")
                    .HasColumnName("productorderdate");

                entity.Property(e => e.Productqty).HasColumnName("productqty");

                entity.Property(e => e.Producttotal).HasColumnName("producttotal");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uname");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Products__DD37D91A4724ED0C");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Pdescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("pdescription");

                entity.Property(e => e.Pimageurl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("pimageurl");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pname");

                entity.Property(e => e.Pqty).HasColumnName("pqty");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Pshow)
                    .IsRequired()
                    .HasColumnName("pshow")
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
