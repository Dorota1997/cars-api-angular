using Microsoft.EntityFrameworkCore.Migrations;

namespace car_themed_app_DataLayer.Migrations
{
    public partial class RemovePriceFromServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "ServiceHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
