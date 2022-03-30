using Microsoft.EntityFrameworkCore.Migrations;

namespace coderush.Migrations
{
    public partial class PartPartnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "InternalPartNumber",
                table: "Product",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalPartNumber",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
