using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Data.Migrations
{
    public partial class AddANewEntityInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxCapacity",
                table: "Events",
                newName: "TicketType");

            migrationBuilder.AddColumn<int>(
                name: "ExhibitionHallId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExhibitionHalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionHallType = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionHalls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ExhibitionHallId",
                table: "Events",
                column: "ExhibitionHallId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionHalls_IsDeleted",
                table: "ExhibitionHalls",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ExhibitionHalls_ExhibitionHallId",
                table: "Events",
                column: "ExhibitionHallId",
                principalTable: "ExhibitionHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ExhibitionHalls_ExhibitionHallId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "ExhibitionHalls");

            migrationBuilder.DropIndex(
                name: "IX_Events_ExhibitionHallId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ExhibitionHallId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TicketType",
                table: "Events",
                newName: "MaxCapacity");
        }
    }
}
