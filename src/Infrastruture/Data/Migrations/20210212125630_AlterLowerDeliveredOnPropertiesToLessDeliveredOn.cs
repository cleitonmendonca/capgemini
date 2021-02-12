using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastruture.Data.Migrations
{
    public partial class AlterLowerDeliveredOnPropertiesToLessDeliveredOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LowerDeliveredDate",
                table: "Importations",
                newName: "LessDeliveredDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessDeliveredDate",
                table: "Importations",
                newName: "LowerDeliveredDate");
        }
    }
}
