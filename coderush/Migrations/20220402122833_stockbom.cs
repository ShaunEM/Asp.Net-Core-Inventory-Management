using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coderush.Migrations
{
    public partial class stockbom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockBundle_Id",
                table: "Stock");

            migrationBuilder.CreateTable(
                name: "StockBilOfMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stock_Id = table.Column<int>(type: "int", nullable: false),
                    Child_Stock_Id = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBilOfMaterial", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBilOfMaterial");

            migrationBuilder.AddColumn<string>(
                name: "StockBundle_Id",
                table: "Stock",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
