﻿// <auto-generated />
using System;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KoiOrderingSystemInJapan.Data.Migrations
{
    [DbContext(typeof(KoiOrderingSystemInJapanContext))]
    [Migration("20241006080850_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Img")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Category__3214EC0784A9C9CB");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.CustomerService", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfPerson")
                        .HasColumnType("int");

                    b.Property<int?>("QuantityService")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Customer__3214EC07FCEC401A");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TravelId");

                    b.ToTable("CustomerService", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("DeliveryStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("PaymentReceived")
                        .HasColumnType("bit");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Delivery__3214EC07F25BCCD6");

                    b.HasIndex("DeliveryStaffId");

                    b.HasIndex("KoiOrderId");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.DeliveryDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Delivery__3214EC072E6A74F4");

                    b.HasIndex("DeliveryId");

                    b.ToTable("DeliveryDetail", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Farm__3214EC070BA1B823");

                    b.ToTable("Farm", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.FarmCategory", b =>
                {
                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("FarmId", "CategoryId")
                        .HasName("PK__FarmCate__4CEB2919BDAC7C61");

                    b.HasIndex("CategoryId");

                    b.ToTable("FarmCategory", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Invoice__3214EC0708D73E19");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiFish", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<Guid?>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__KoiFish__3214EC0717958643");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SizeId");

                    b.ToTable("KoiFish", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__KoiOrder__3214EC0732E1F1C2");

                    b.HasIndex("CustomerId");

                    b.HasIndex(new[] { "InvoiceId" }, "UQ__KoiOrder__D796AAB453F8EE31")
                        .IsUnique()
                        .HasFilter("[InvoiceId] IS NOT NULL");

                    b.ToTable("KoiOrder", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiFishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KoiOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__OrderDet__3214EC070E39EDDC");

                    b.HasIndex("KoiFishId");

                    b.HasIndex("KoiOrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CustomerServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProposalDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponseBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResponseDate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("SaleStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Sales__3214EC07D581FD9D");

                    b.HasIndex("CustomerServiceId");

                    b.HasIndex("ResponseBy");

                    b.HasIndex("SaleStaffId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ServiceName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Service__3214EC07620A1376");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CustomerServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__ServiceO__3214EC07E25BE609");

                    b.HasIndex("CustomerServiceId");

                    b.HasIndex(new[] { "InvoiceId" }, "UQ__ServiceO__D796AAB4864698CD")
                        .IsUnique()
                        .HasFilter("[InvoiceId] IS NOT NULL");

                    b.ToTable("ServiceOrder", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("SizeInCm")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Size__3214EC07728D2CA4");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__Travel__3214EC07BD769DC2");

                    b.ToTable("Travel", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.TravelFarm", b =>
                {
                    b.Property<Guid>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("TravelId", "FarmId")
                        .HasName("PK__TravelFa__67E6E99E614E8687");

                    b.HasIndex("FarmId");

                    b.ToTable("TravelFarm", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateOnly?>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Firstname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__User__3214EC075E78D140");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ServiceCustomerService", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServiceId", "CustomerServiceId")
                        .HasName("PK__ServiceC__D4E0644762FAFE8C");

                    b.HasIndex("CustomerServiceId");

                    b.ToTable("ServiceCustomerService", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.CustomerService", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "Customer")
                        .WithMany("CustomerServices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__CustomerS__Custo__4316F928");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Travel", "Travel")
                        .WithMany("CustomerServices")
                        .HasForeignKey("TravelId")
                        .HasConstraintName("FK__CustomerS__Trave__440B1D61");

                    b.Navigation("Customer");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Delivery", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "DeliveryStaff")
                        .WithMany("Deliveries")
                        .HasForeignKey("DeliveryStaffId")
                        .HasConstraintName("FK__Delivery__Delive__6B24EA82");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "KoiOrder")
                        .WithMany("Deliveries")
                        .HasForeignKey("KoiOrderId")
                        .HasConstraintName("FK__Delivery__KoiOrd__6A30C649");

                    b.Navigation("DeliveryStaff");

                    b.Navigation("KoiOrder");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.DeliveryDetail", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Delivery", "Delivery")
                        .WithMany("DeliveryDetails")
                        .HasForeignKey("DeliveryId")
                        .HasConstraintName("FK__DeliveryD__Deliv__6E01572D");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.FarmCategory", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Category", "Category")
                        .WithMany("FarmCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__FarmCateg__Categ__52593CB8");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Farm", "Farm")
                        .WithMany("FarmCategories")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK__FarmCateg__FarmI__5165187F");

                    b.Navigation("Category");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiFish", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Category", "Category")
                        .WithMany("KoiFishes")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__KoiFish__Categor__5812160E");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Size", "Size")
                        .WithMany("KoiFishes")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK__KoiFish__SizeId__571DF1D5");

                    b.Navigation("Category");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "Customer")
                        .WithMany("KoiOrders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__KoiOrder__Custom__628FA481");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Invoice", "Invoice")
                        .WithOne("KoiOrder")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "InvoiceId")
                        .HasConstraintName("FK__KoiOrder__Invoic__6383C8BA");

                    b.Navigation("Customer");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiFish", "KoiFish")
                        .WithMany("OrderDetails")
                        .HasForeignKey("KoiFishId")
                        .HasConstraintName("FK__OrderDeta__KoiFi__66603565");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "KoiOrder")
                        .WithMany("OrderDetails")
                        .HasForeignKey("KoiOrderId")
                        .HasConstraintName("FK__OrderDeta__KoiOr__6754599E");

                    b.Navigation("KoiFish");

                    b.Navigation("KoiOrder");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Sale", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.CustomerService", "CustomerService")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerServiceId")
                        .HasConstraintName("FK__Sales__CustomerS__4AB81AF0");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "ResponseByNavigation")
                        .WithMany("SaleResponseByNavigations")
                        .HasForeignKey("ResponseBy")
                        .HasConstraintName("FK__Sales__ResponseB__4CA06362");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "SaleStaff")
                        .WithMany("SaleSaleStaffs")
                        .HasForeignKey("SaleStaffId")
                        .HasConstraintName("FK__Sales__SaleStaff__4BAC3F29");

                    b.Navigation("CustomerService");

                    b.Navigation("ResponseByNavigation");

                    b.Navigation("SaleStaff");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.CustomerService", "CustomerService")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("CustomerServiceId")
                        .HasConstraintName("FK__ServiceOr__Custo__5DCAEF64");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Invoice", "Invoice")
                        .WithOne("ServiceOrder")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", "InvoiceId")
                        .HasConstraintName("FK__ServiceOr__Invoi__5EBF139D");

                    b.Navigation("CustomerService");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.TravelFarm", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Farm", "Farm")
                        .WithMany("TravelFarms")
                        .HasForeignKey("FarmId")
                        .IsRequired()
                        .HasConstraintName("FK__TravelFar__FarmI__3C69FB99");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Travel", "Travel")
                        .WithMany("TravelFarms")
                        .HasForeignKey("TravelId")
                        .IsRequired()
                        .HasConstraintName("FK__TravelFar__Trave__3B75D760");

                    b.Navigation("Farm");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("ServiceCustomerService", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.CustomerService", null)
                        .WithMany()
                        .HasForeignKey("CustomerServiceId")
                        .IsRequired()
                        .HasConstraintName("FK__ServiceCu__Custo__47DBAE45");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("FK__ServiceCu__Servi__46E78A0C");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Category", b =>
                {
                    b.Navigation("FarmCategories");

                    b.Navigation("KoiFishes");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.CustomerService", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Delivery", b =>
                {
                    b.Navigation("DeliveryDetails");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Farm", b =>
                {
                    b.Navigation("FarmCategories");

                    b.Navigation("TravelFarms");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Invoice", b =>
                {
                    b.Navigation("KoiOrder");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiFish", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Size", b =>
                {
                    b.Navigation("KoiFishes");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Travel", b =>
                {
                    b.Navigation("CustomerServices");

                    b.Navigation("TravelFarms");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.User", b =>
                {
                    b.Navigation("CustomerServices");

                    b.Navigation("Deliveries");

                    b.Navigation("KoiOrders");

                    b.Navigation("SaleResponseByNavigations");

                    b.Navigation("SaleSaleStaffs");
                });
#pragma warning restore 612, 618
        }
    }
}