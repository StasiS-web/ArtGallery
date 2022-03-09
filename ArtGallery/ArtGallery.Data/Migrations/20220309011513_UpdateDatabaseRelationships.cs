using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class UpdateDatabaseRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_ShoppingCarts_ShoppingCartId",
                table: "Arts");

            migrationBuilder.AlterColumn<decimal>(
                name: "ShoppingCartId",
                table: "Arts",
                type: "decimal",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_ShoppingCarts_ShoppingCartId",
                table: "Arts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Price",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arts_ShoppingCarts_ShoppingCartId",
                table: "Arts");

            migrationBuilder.AlterColumn<decimal>(
                name: "ShoppingCartId",
                table: "Arts",
                type: "decimal",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AddForeignKey(
                name: "FK_Arts_ShoppingCarts_ShoppingCartId",
                table: "Arts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Price");
        }
    }
}
