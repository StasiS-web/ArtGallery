using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class UpdateEntityShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ShoppingCartId",
                table: "ArtGalleryUser",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ArtGalleryUser_ShoppingCartId",
                table: "ArtGalleryUser",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtGalleryUser_ShoppingCarts_ShoppingCartId",
                table: "ArtGalleryUser",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Price",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtGalleryUser_ShoppingCarts_ShoppingCartId",
                table: "ArtGalleryUser");

            migrationBuilder.DropIndex(
                name: "IX_ArtGalleryUser_ShoppingCartId",
                table: "ArtGalleryUser");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ArtGalleryUser");
        }
    }
}
