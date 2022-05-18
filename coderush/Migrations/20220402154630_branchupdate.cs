using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coderush.Migrations
{
    public partial class branchupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchArea");

            migrationBuilder.DropTable(
                name: "StockBundle");

            migrationBuilder.DropTable(
                name: "StockBundleDetail");

            migrationBuilder.DropTable(
                name: "StockBundleType");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UnitOfMeasure",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockType",
                newName: "StockTypeId");

            migrationBuilder.RenameColumn(
                name: "Stock_Id",
                table: "StockBilOfMaterial",
                newName: "StockId");

            migrationBuilder.RenameColumn(
                name: "Child_Stock_Id",
                table: "StockBilOfMaterial",
                newName: "Child_StockId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StockBilOfMaterial",
                newName: "StockBilOfMaterialId");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasure_Id",
                table: "Stock",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameColumn(
                name: "StockType_Id",
                table: "Stock",
                newName: "StockTypeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stock",
                newName: "StockName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stock",
                newName: "StockId");

            migrationBuilder.CreateTable(
                name: "BranchStore",
                columns: table => new
                {
                    BranchStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchStoreName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchStore", x => x.BranchStoreId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchStore");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "UnitOfMeasure",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StockTypeId",
                table: "StockType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "StockBilOfMaterial",
                newName: "Stock_Id");

            migrationBuilder.RenameColumn(
                name: "Child_StockId",
                table: "StockBilOfMaterial",
                newName: "Child_Stock_Id");

            migrationBuilder.RenameColumn(
                name: "StockBilOfMaterialId",
                table: "StockBilOfMaterial",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "Stock",
                newName: "UnitOfMeasure_Id");

            migrationBuilder.RenameColumn(
                name: "StockTypeId",
                table: "Stock",
                newName: "StockType_Id");

            migrationBuilder.RenameColumn(
                name: "StockName",
                table: "Stock",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Stock",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "BranchArea",
                columns: table => new
                {
                    BranchAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AreaName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchArea", x => x.BranchAreaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StockBundle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BundleCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StockBundleType_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBundle", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StockBundleDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    Stock_Id = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    UnitPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBundleDetail", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StockBundleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBundleType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
