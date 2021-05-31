using Microsoft.EntityFrameworkCore.Migrations;

namespace PastryShopAPI.Migrations
{
    public partial class removedPriceFlavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flavors",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Flavors",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Categories",
                type: "bigint",
                nullable: true);
        }
    }
}
