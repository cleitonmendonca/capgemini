using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastruture.Data.Migrations
{
    public partial class AlterDeliveredPropertyInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleiveredOn",
                table: "Products",
                newName: "DeliveredOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveredOn",
                table: "Products",
                newName: "DeleiveredOn");
        }
    }
}
