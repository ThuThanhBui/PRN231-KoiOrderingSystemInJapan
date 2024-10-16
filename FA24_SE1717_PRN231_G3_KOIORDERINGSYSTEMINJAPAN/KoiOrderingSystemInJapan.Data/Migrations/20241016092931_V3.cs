using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystemInJapan.Data.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "KoiFish",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "KoiFish");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
