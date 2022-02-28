#nullable disable

namespace ArtGallery.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddImagesToBlogPostsAndDataValidationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentContent",
                table: "Comments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogPosts",
                type: "nvarchar(3500)",
                maxLength: 3500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4500);

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "CommentContent",
                table: "Comments",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogPosts",
                type: "nvarchar(max)",
                maxLength: 4500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3500)",
                oldMaxLength: 3500);
        }
    }
}
