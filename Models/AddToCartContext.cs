using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookDatabaseApi.Models
{
    public partial class AddToCartContext : DbContext
    {
        public AddToCartContext()
        {
        }

        public AddToCartContext(DbContextOptions<AddToCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addtocart> Addtocarts { get; set; }
        public virtual DbSet<BookTable> BookTables { get; set; }
        public virtual DbSet<InstrumentTable> InstrumentTables { get; set; }
        public virtual DbSet<NewBookTable> NewBookTables { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<UserPayment> UserPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AddToCart;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Addtocart>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6ED9E9A7C95");

                entity.ToTable("ADDTOCART");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .HasMaxLength(253)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(245)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookTable>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6EDE63312E5");

                entity.ToTable("BookTable");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .HasMaxLength(253)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(245)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InstrumentTable>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6ED3325D822");

                entity.ToTable("InstrumentTable");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(560)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(290)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NewBookTable>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tmp_ms_x__B40CC6ED8AEC3351");

                entity.ToTable("NewBookTable");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Category)
                    .HasMaxLength(253)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(245)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.Pass)
                    .HasName("PK__tmp_ms_x__8320F63FB229177D");

                entity.ToTable("UserLog");

                entity.Property(e => e.Pass)
                    .ValueGeneratedNever()
                    .HasColumnName("pass");

                entity.Property(e => e.UserName)
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPayment>(entity =>
            {
                entity.HasKey(e => e.Cvv)
                    .HasName("PK__UserPaym__D83656428F3B399F");

                entity.ToTable("UserPayment");

                entity.HasIndex(e => e.CardNumber, "UQ__UserPaym__A4E9FFE9701A2139")
                    .IsUnique();

                entity.Property(e => e.Cvv)
                    .ValueGeneratedNever()
                    .HasColumnName("cvv");

                entity.Property(e => e.CardHname)
                    .HasMaxLength(145)
                    .IsUnicode(false)
                    .HasColumnName("CardHName");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(145)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
