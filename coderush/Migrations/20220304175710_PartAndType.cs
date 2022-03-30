using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coderush.Migrations
{
    public partial class PartAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Part",
                newName: "ProductionRemarks");

            migrationBuilder.RenameColumn(
                name: "SupplierTypeId",
                table: "Part",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "Part",
                newName: "PartName");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Part",
                newName: "InternalPartNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Part",
                newName: "Foorprint");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Part",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ContactPerson",
                table: "Part",
                newName: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "PartTypeId",
                table: "Part",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PartType",
                columns: table => new
                {
                    PartTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PartTypeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartType", x => x.PartTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartType");

            migrationBuilder.DropColumn(
                name: "PartTypeId",
                table: "Part");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "Part",
                newName: "SupplierTypeId");

            migrationBuilder.RenameColumn(
                name: "ProductionRemarks",
                table: "Part",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "PartName",
                table: "Part",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "InternalPartNumber",
                table: "Part",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Foorprint",
                table: "Part",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Part",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Part",
                newName: "ContactPerson");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Part",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Part",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
