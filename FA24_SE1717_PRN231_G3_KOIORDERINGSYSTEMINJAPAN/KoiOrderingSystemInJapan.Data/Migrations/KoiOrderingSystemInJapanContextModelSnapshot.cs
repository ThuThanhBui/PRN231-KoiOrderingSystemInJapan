﻿// <auto-generated />
using System;
using KoiOrderingSystemInJapan.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;



namespace KoiOrderingSystemInJapan.Data.Migrations
{
    [DbContext(typeof(KoiOrderingSystemInJapanContext))]
    partial class KoiOrderingSystemInJapanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.BookingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TravelId");

                    b.ToTable("BookingRequest", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeliveryStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PaymentReceived")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryStaffId");

                    b.HasIndex("KoiOrderId")
                        .IsUnique()
                        .HasFilter("[KoiOrderId] IS NOT NULL");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.DeliveryDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("DeliveryDetail", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Farm", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.FarmCategory", b =>
                {
                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FarmId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("FarmCategory", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiFish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSold")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("KoiFish", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceId")
                        .IsUnique()
                        .HasFilter("[InvoiceId] IS NOT NULL");

                    b.ToTable("KoiOrder", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiFishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KoiOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KoiFishId");

                    b.HasIndex("KoiOrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("BookingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProposalDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponseBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SaleStaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingRequestId")
                        .IsUnique()
                        .HasFilter("[BookingRequestId] IS NOT NULL");

                    b.HasIndex("SaleStaffId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("BookingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingRequestId");

                    b.HasIndex("InvoiceId")
                        .IsUnique()
                        .HasFilter("[InvoiceId] IS NOT NULL");

                    b.ToTable("ServiceOrder", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceXBookingRequest", b =>
                {
                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ServiceId", "BookingRequestId");

                    b.HasIndex("BookingRequestId");

                    b.ToTable("ServiceXBookingRequest", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KoiFishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SizeInCm")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("SizeInGram")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KoiFishId")
                        .IsUnique()
                        .HasFilter("[KoiFishId] IS NOT NULL");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Travel", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.TravelFarm", b =>
                {
                    b.Property<Guid>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TravelId", "FarmId");

                    b.HasIndex("FarmId");

                    b.ToTable("TravelFarm", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWId()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly?>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.BookingRequest", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "Customer")
                        .WithMany("BookingRequests")
                        .HasForeignKey("CustomerId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Travel", "Travel")
                        .WithMany("BookingRequests")
                        .HasForeignKey("TravelId");

                    b.Navigation("Customer");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Delivery", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "DeliveryStaff")
                        .WithMany("Deliveries")
                        .HasForeignKey("DeliveryStaffId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "KoiOrder")
                        .WithOne("Deliveries")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.Delivery", "KoiOrderId");

                    b.Navigation("DeliveryStaff");

                    b.Navigation("KoiOrder");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.DeliveryDetail", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Delivery", "Delivery")
                        .WithMany("DeliveryDetails")
                        .HasForeignKey("DeliveryId");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.FarmCategory", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Category", "Category")
                        .WithMany("FarmCategories")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Farm", "Farm")
                        .WithMany("FarmCategories")
                        .HasForeignKey("FarmId")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiFish", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Category", "Category")
                        .WithMany("KoiFishes")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "Customer")
                        .WithMany("KoiOrders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Invoice", "Invoice")
                        .WithOne("KoiOrder")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "InvoiceId");

                    b.Navigation("Customer");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiFish", "KoiFish")
                        .WithMany("OrderDetails")
                        .HasForeignKey("KoiFishId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiOrder", "KoiOrder")
                        .WithMany("OrderDetails")
                        .HasForeignKey("KoiOrderId");

                    b.Navigation("KoiFish");

                    b.Navigation("KoiOrder");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Sale", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.BookingRequest", "BookingRequest")
                        .WithOne("Sale")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.Sale", "BookingRequestId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.User", "SaleStaff")
                        .WithMany("SaleSaleStaffs")
                        .HasForeignKey("SaleStaffId");

                    b.Navigation("BookingRequest");

                    b.Navigation("SaleStaff");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.BookingRequest", "BookingRequest")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("BookingRequestId");

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Invoice", "Invoice")
                        .WithOne("ServiceOrder")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.ServiceOrder", "InvoiceId");

                    b.Navigation("BookingRequest");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.ServiceXBookingRequest", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.BookingRequest", "BookingRequest")
                        .WithMany("ServiceXBookingRequest")
                        .HasForeignKey("BookingRequestId")
                        .IsRequired();

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Service", "Service")
                        .WithMany("ServiceXBookingRequest")
                        .HasForeignKey("ServiceId")
                        .IsRequired();

                    b.Navigation("BookingRequest");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Size", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.KoiFish", "KoiFish")
                        .WithOne("Size")
                        .HasForeignKey("KoiOrderingSystemInJapan.Data.Models.Size", "KoiFishId");

                    b.Navigation("KoiFish");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.TravelFarm", b =>
                {
                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Farm", "Farm")
                        .WithMany("TravelFarms")
                        .HasForeignKey("FarmId")
                        .IsRequired();

                    b.HasOne("KoiOrderingSystemInJapan.Data.Models.Travel", "Travel")
                        .WithMany("TravelFarms")
                        .HasForeignKey("TravelId")
                        .IsRequired();

                    b.Navigation("Farm");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Category", b =>
                {
                    b.Navigation("FarmCategories");

                    b.Navigation("KoiFishes");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.BookingRequest", b =>
                {
                    b.Navigation("Sale");

                    b.Navigation("ServiceOrders");

                    b.Navigation("ServiceXBookingRequest");
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

                    b.Navigation("Size");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.KoiOrder", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Service", b =>
                {
                    b.Navigation("ServiceXBookingRequest");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.Travel", b =>
                {
                    b.Navigation("BookingRequests");

                    b.Navigation("TravelFarms");
                });

            modelBuilder.Entity("KoiOrderingSystemInJapan.Data.Models.User", b =>
                {
                    b.Navigation("BookingRequests");

                    b.Navigation("Deliveries");

                    b.Navigation("KoiOrders");

                    b.Navigation("SaleSaleStaffs");
                });
#pragma warning restore 612, 618
        }
    }
}
