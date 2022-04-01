using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ArtsOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ArtsOrders");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Events",
                type: "bit",
                nullable: true);
        }
    }
}
