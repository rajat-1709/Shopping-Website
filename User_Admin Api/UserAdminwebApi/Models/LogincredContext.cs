using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserAdminwebApi.Models
{
    public partial class LogincredContext : DbContext
    {
        public LogincredContext()
        {
        }

        public LogincredContext(DbContextOptions<LogincredContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admindetail> Admindetails { get; set; }
        public virtual DbSet<Userdetail> Userdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=Logincred;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admindetail>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__admindet__F3DBC5737404F28F");

                entity.ToTable("admindetails");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Userdetail>(entity =>
            {
                entity.HasKey(e => e.Uname)
                    .HasName("PK__Userdeta__C7D2484F1589F533");

                entity.Property(e => e.Uname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("uname");

                entity.Property(e => e.Addressofuser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addressofuser");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("passwd");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(30)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Useractive)
                    .HasColumnName("useractive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Userid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
