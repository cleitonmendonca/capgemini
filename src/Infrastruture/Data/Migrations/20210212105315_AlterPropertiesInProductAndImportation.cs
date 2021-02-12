using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastruture.Data.Migrations
{
    public partial class AlterPropertiesInProductAndImportation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalItems",
                table: "Importations");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Importations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalItems",
                table: "Importations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalValue",
                table: "Importations",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
