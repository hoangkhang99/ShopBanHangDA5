using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopBanHangDA5.Models
{
    public partial class BanHangContext : DbContext
    {
        internal IEnumerable<Product> products;

        public BanHangContext()
        {
        }

        public BanHangContext(DbContextOptions<BanHangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<ImportOrder> ImportOrder { get; set; }
        public virtual DbSet<ImportOrderDetail> ImportOrderDetail { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Name=db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdminEmail)
                    .HasColumnName("admin_email")
                    .HasMaxLength(50);

                entity.Property(e => e.AdminPassword)
                    .HasColumnName("admin_password")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BrandDesc)
                    .IsRequired()
                    .HasColumnName("brand_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CategoryDesc)
                    .IsRequired()
                    .HasColumnName("category_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommentCustomersId)
                    .HasColumnName("comment_customers_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommentDesc)
                    .HasColumnName("comment_desc")
                    .HasColumnType("ntext");

                entity.Property(e => e.CommentProductId)
                    .HasColumnName("comment_product_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CommentCustomers)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CommentCustomersId)
                    .HasConstraintName("FK_Comment_Customers");

                entity.HasOne(d => d.CommentProduct)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CommentProductId)
                    .HasConstraintName("FK_Comment_Product");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__CD65CB856312CA4A");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("customer_email")
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasColumnName("customer_password")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__HoaDon__465962292F9B7BF9");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderDiachi)
                    .IsRequired()
                    .HasColumnName("order_diachi")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__HoaDon__customer__403A8C7D");
            });

            modelBuilder.Entity<ImportOrder>(entity =>
            {
                entity.ToTable("Import_order");

                entity.Property(e => e.ImportOrderId)
                    .HasColumnName("import_order_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderCustomersId)
                    .HasColumnName("import_order_customers_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderName)
                    .HasColumnName("import_order_name")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderPrice).HasColumnName("import_order_price");

                entity.HasOne(d => d.ImportOrderCustomers)
                    .WithMany(p => p.ImportOrder)
                    .HasForeignKey(d => d.ImportOrderCustomersId)
                    .HasConstraintName("FK_Import_order_Customers");
            });

            modelBuilder.Entity<ImportOrderDetail>(entity =>
            {
                entity.ToTable("Import_order_detail");

                entity.Property(e => e.ImportOrderDetailId)
                    .HasColumnName("import_order_detail_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderDetailImportOrderId)
                    .HasColumnName("import_order_detail_import_order_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderDetailPrice).HasColumnName("import_order_detail_price");

                entity.Property(e => e.ImportOrderDetailProductId)
                    .HasColumnName("import_order_detail_product_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderDetailProductName)
                    .HasColumnName("import_order_detail_product_name")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ImportOrderDetailQuantity).HasColumnName("import_order_detail_quantity");

                entity.HasOne(d => d.ImportOrderDetailImportOrder)
                    .WithMany(p => p.ImportOrderDetail)
                    .HasForeignKey(d => d.ImportOrderDetailImportOrderId)
                    .HasConstraintName("FK_Import_order_detail_Import_order");

                entity.HasOne(d => d.ImportOrderDetailProduct)
                    .WithMany(p => p.ImportOrderDetail)
                    .HasForeignKey(d => d.ImportOrderDetailProductId)
                    .HasConstraintName("FK_Import_order_detail_Product");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NewsDesc)
                    .HasColumnName("news_desc")
                    .HasColumnType("text");

                entity.Property(e => e.NewsImage)
                    .HasColumnName("news_image")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("Order_details");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("order_details_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductSalesQuantity).HasColumnName("product_sales_quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_det__order__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_det__produ__4AB81AF0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductColor)
                    .IsRequired()
                    .HasColumnName("product_color")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductDesc)
                    .IsRequired()
                    .HasColumnName("product_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImage)
                    .HasColumnName("product_image")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(20);

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.Property(e => e.ProductSize)
                    .IsRequired()
                    .HasColumnName("product_size")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__brand_i__3B75D760");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__categor__3A81B327");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.CouponId);

                entity.Property(e => e.CouponId)
                    .HasColumnName("Coupon_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CouponCondition)
                    .HasColumnName("Coupon_condition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CouponName)
                    .HasColumnName("Coupon_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.Property(e => e.SlideId)
                    .HasColumnName("slide_id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SlideImage)
                    .HasColumnName("slide_image")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
