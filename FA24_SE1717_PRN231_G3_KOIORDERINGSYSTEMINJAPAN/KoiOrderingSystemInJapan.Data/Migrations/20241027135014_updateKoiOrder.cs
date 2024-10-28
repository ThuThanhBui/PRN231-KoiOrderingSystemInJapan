using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystemInJapan.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateKoiOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "KoiOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "KoiOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGift",
                table: "KoiOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "KoiOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "KoiOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "KoiOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "KoiOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "KoiOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Invoice",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "Invoice",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "IsGift",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "KoiOrder");

            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "Invoice");
        }
    }
}
