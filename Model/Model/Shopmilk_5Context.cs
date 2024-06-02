using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.Model
{
    public partial class Shopmilk_5Context : DbContext
    {
        public Shopmilk_5Context()
        {
        }

        public Shopmilk_5Context(DbContextOptions<Shopmilk_5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartDetail> CartDetails { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SS1MLQ2\\MSSQLSERVER01;Database=Shopmilk_5;Integrated security=true; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CaId)
                    .HasName("PK__Cart__646AFE0EA07254BE");

                entity.ToTable("Cart");

                entity.Property(e => e.CaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ca_id");

                entity.Property(e => e.CaDate)
                    .HasColumnType("date")
                    .HasColumnName("Ca_date");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_id");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Cart__U_id__34C8D9D1");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasKey(e => new { e.CaId, e.ProdId })
                    .HasName("PK__CartDeta__5103A6A552AF6224");

                entity.ToTable("CartDetail");

                entity.Property(e => e.CaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ca_id");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("prod_id");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("prod_price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Ca)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartDetai__Ca_id__38996AB5");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartDetai__prod___37A5467C");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId)
                    .HasName("PK__Category__2968AA5E7AC842BE");

                entity.ToTable("Category");

                entity.Property(e => e.CateId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Cate_id");

                entity.Property(e => e.CateName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cate_name");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PK__Gallery__15398ADAE8AAEB65");

                entity.ToTable("Gallery");

                entity.Property(e => e.GId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("G_id");

                entity.Property(e => e.GThumbnail)
                    .HasMaxLength(255)
                    .HasColumnName("G_thumbnail");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Prod_id");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Galleries)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__Gallery__Prod_id__29572725");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrId)
                    .HasName("PK__Orders__659881055534DECC");

                entity.Property(e => e.OrId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Or_id");

                entity.Property(e => e.OrDate)
                    .HasColumnType("date")
                    .HasColumnName("Or_date");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_id");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Orders__U_id__2E1BDC42");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrId, e.ProdId })
                    .HasName("PK__OrdersDe__C9CD2D3713396AB0");

                entity.ToTable("OrdersDetail");

                entity.Property(e => e.OrId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Or_id");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Prod_id");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Prod_price");

                entity.HasOne(d => d.Or)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.OrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdersDet__Or_id__30F848ED");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdersDet__Prod___31EC6D26");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__C55AC32B78069248");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Prod_id");

                entity.Property(e => e.CateId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Cate_id");

                entity.Property(e => e.ProdCanningSpecification).HasColumnName("Prod_canningSpecification");

                entity.Property(e => e.ProdCapacity).HasColumnName("Prod_capacity");

                entity.Property(e => e.ProdDescription).HasColumnName("Prod_description");

                entity.Property(e => e.ProdExpiry)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Prod_expiry");

                entity.Property(e => e.ProdImageUrl).HasColumnName("Prod_image_URL");

                entity.Property(e => e.ProdManual)
                    .HasMaxLength(255)
                    .HasColumnName("Prod_manual");

                entity.Property(e => e.ProdPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Prod_price");

                entity.Property(e => e.ProdTitle)
                    .HasMaxLength(255)
                    .HasColumnName("Prod_title");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__Product__Cate_id__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__Users__5A3965137C6197DE");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_id");

                entity.Property(e => e.UEmail)
                    .HasMaxLength(100)
                    .HasColumnName("U_email");

                entity.Property(e => e.UPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_password");

                entity.Property(e => e.URole)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("U_Role");

                entity.Property(e => e.UUserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_userName");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("PK__Voucher__B35D778C387A7ED2");

                entity.ToTable("Voucher");

                entity.Property(e => e.VId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("V_Id");

                entity.Property(e => e.UId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_Id");

                entity.Property(e => e.VPriceSale).HasColumnName("V_PriceSale");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Voucher__U_Id__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
