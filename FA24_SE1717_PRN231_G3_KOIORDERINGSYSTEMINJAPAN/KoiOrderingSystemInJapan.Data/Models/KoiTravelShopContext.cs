﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class KoiTravelShopContext : DbContext
{
    public KoiTravelShopContext()
    {
    }

    public KoiTravelShopContext(DbContextOptions<KoiTravelShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerService> CustomerServices { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DeliveryDetail> DeliveryDetails { get; set; }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<FarmCategory> FarmCategories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<KoiOrder> KoiOrders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<TravelFarm> TravelFarms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07C0E45651");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Img).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0760461D60");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customer__UserId__4316F928");
        });

        modelBuilder.Entity<CustomerService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC073BC6E14A");

            entity.ToTable("CustomerService");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerServices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerS__Custo__45F365D3");

            entity.HasOne(d => d.Travel).WithMany(p => p.CustomerServices)
                .HasForeignKey(d => d.TravelId)
                .HasConstraintName("FK__CustomerS__Trave__46E78A0C");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07E0CA9A10");

            entity.ToTable("Delivery");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.DeliveryStaff).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DeliveryStaffId)
                .HasConstraintName("FK__Delivery__Delive__6B24EA82");

            entity.HasOne(d => d.KoiOrder).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.KoiOrderId)
                .HasConstraintName("FK__Delivery__KoiOrd__6A30C649");
        });

        modelBuilder.Entity<DeliveryDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07EB3FFA8E");

            entity.ToTable("DeliveryDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Delivery).WithMany(p => p.DeliveryDetails)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("FK__DeliveryD__Deliv__6E01572D");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Farm__3214EC072CEBCE4F");

            entity.ToTable("Farm");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Owner).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<FarmCategory>(entity =>
        {
            entity.HasKey(e => new { e.FarmId, e.CategoryId }).HasName("PK__FarmCate__4CEB29196E17428D");

            entity.ToTable("FarmCategory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.FarmCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FarmCateg__Categ__5441852A");

            entity.HasOne(d => d.Farm).WithMany(p => p.FarmCategories)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FarmCateg__FarmI__534D60F1");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC07A198B1E7");

            entity.ToTable("Invoice");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFish__3214EC07E46D9EE7");

            entity.ToTable("KoiFish");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__KoiFish__Categor__59FA5E80");

            entity.HasOne(d => d.Size).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__KoiFish__SizeId__59063A47");
        });

        modelBuilder.Entity<KoiOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiOrder__3214EC077F04A601");

            entity.ToTable("KoiOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.KoiOrders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__KoiOrder__Custom__628FA481");

            entity.HasOne(d => d.Invoice).WithMany(p => p.KoiOrders)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__KoiOrder__Invoic__6383C8BA");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC0792DF444A");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK__OrderDeta__KoiFi__66603565");

            entity.HasOne(d => d.KoiOrder).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiOrderId)
                .HasConstraintName("FK__OrderDeta__KoiOr__6754599E");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC0767213DB9");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustomerService).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerServiceId)
                .HasConstraintName("FK__Sales__CustomerS__4D94879B");

            entity.HasOne(d => d.SaleStaff).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SaleStaffId)
                .HasConstraintName("FK__Sales__SaleStaff__4E88ABD4");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC07A85B1BF5");

            entity.ToTable("Service");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasMany(d => d.CustomerServices).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServiceCustomerService",
                    r => r.HasOne<CustomerService>().WithMany()
                        .HasForeignKey("CustomerServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ServiceCu__Custo__4AB81AF0"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ServiceCu__Servi__49C3F6B7"),
                    j =>
                    {
                        j.HasKey("ServiceId", "CustomerServiceId").HasName("PK__ServiceC__D4E064474C79E18F");
                        j.ToTable("ServiceCustomerService");
                    });
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceO__3214EC07199B577B");

            entity.ToTable("ServiceOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustomerService).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.CustomerServiceId)
                .HasConstraintName("FK__ServiceOr__Custo__5EBF139D");

            entity.HasOne(d => d.Invoice).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__ServiceOr__Invoi__5FB337D6");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Size__3214EC07EEB6DAE2");

            entity.ToTable("Size");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.SizeInCm).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Travel__3214EC07F908B7CD");

            entity.ToTable("Travel");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TravelFarm>(entity =>
        {
            entity.HasKey(e => new { e.TravelId, e.FarmId }).HasName("PK__TravelFa__67E6E99E7D690691");

            entity.ToTable("TravelFarm");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Farm).WithMany(p => p.TravelFarms)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TravelFar__FarmI__3C69FB99");

            entity.HasOne(d => d.Travel).WithMany(p => p.TravelFarms)
                .HasForeignKey(d => d.TravelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TravelFar__Trave__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0742347F05");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}