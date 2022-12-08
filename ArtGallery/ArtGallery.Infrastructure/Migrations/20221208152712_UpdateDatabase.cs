using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Infrastructure.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtsOrders_ArtGalleryUser_UserId",
                table: "ArtsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTransactions_ArtGalleryUser_UserId",
                table: "BookingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ArtGalleryUser_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsOrders_ArtGalleryUser_UserId",
                table: "EventsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_ArtGalleryUser_UserId",
                table: "SaleTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_ArtGalleryUser_UserId",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "ArtGalleryUserId",
                table: "SaleTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtGalleryUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtGalleryUserId",
                table: "BookingTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--eMTBpUc4--/c_fit,h_400,w_400/v1646156777/app_gallery/image-from-id-405327-jpeg_njsywp.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--R7kMhOFw--/c_fit,h_400,w_400/v1646157537/app_gallery/image-from-id-556828-jpeg_pvzrkd.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--0W3cGmHR--/c_fit,h_400,w_400/v1646156702/app_gallery/Artist_painting-jpeg_nn02fh.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--qQQZbUqy--/c_fit,h_400,w_400/v1648590618/app_gallery/arun-prakash-unsplash_tuluof.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--qQQZbUqy--/c_fit,h_400,w_400/v1648590618/app_gallery/arun-prakash-unsplash_tuluof.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Question",
                value: "Are pets permitted in the Gallery?");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_ArtGalleryUserId",
                table: "SaleTransactions",
                column: "ArtGalleryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArtGalleryUserId",
                table: "Comments",
                column: "ArtGalleryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTransactions_ArtGalleryUserId",
                table: "BookingTransactions",
                column: "ArtGalleryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtsOrders_AspNetUsers_UserId",
                table: "ArtsOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTransactions_ArtGalleryUser_ArtGalleryUserId",
                table: "BookingTransactions",
                column: "ArtGalleryUserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTransactions_AspNetUsers_UserId",
                table: "BookingTransactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ArtGalleryUser_ArtGalleryUserId",
                table: "Comments",
                column: "ArtGalleryUserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsOrders_AspNetUsers_UserId",
                table: "EventsOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_ArtGalleryUser_ArtGalleryUserId",
                table: "SaleTransactions",
                column: "ArtGalleryUserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_AspNetUsers_UserId",
                table: "SaleTransactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtsOrders_AspNetUsers_UserId",
                table: "ArtsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTransactions_ArtGalleryUser_ArtGalleryUserId",
                table: "BookingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingTransactions_AspNetUsers_UserId",
                table: "BookingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ArtGalleryUser_ArtGalleryUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsOrders_AspNetUsers_UserId",
                table: "EventsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_ArtGalleryUser_ArtGalleryUserId",
                table: "SaleTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleTransactions_AspNetUsers_UserId",
                table: "SaleTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_SaleTransactions_ArtGalleryUserId",
                table: "SaleTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ArtGalleryUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_BookingTransactions_ArtGalleryUserId",
                table: "BookingTransactions");

            migrationBuilder.DropColumn(
                name: "ArtGalleryUserId",
                table: "SaleTransactions");

            migrationBuilder.DropColumn(
                name: "ArtGalleryUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ArtGalleryUserId",
                table: "BookingTransactions");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646156702/app_gallery/Artist_painting-jpeg_nn02fh.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646157537/app_gallery/image-from-id-556828-jpeg_pvzrkd.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--eMTBpUc4--/c_fit,h_400,w_400/v1646156777/app_gallery/image-from-id-405327-jpeg_njsywp.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--GIhqN_we--/c_fit,h_400,w_400/v1648590618/app_gallery/arun-prakash-unsplash_tuluof.jpg");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlImage",
                value: "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--7d9hBVji--/c_fit,h_400,w_400/v1648591070/app_gallery/annie-spratt-unsplash_e2hv3u.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Question",
                value: "Are pets permitted in the GallerY?");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtsOrders_ArtGalleryUser_UserId",
                table: "ArtsOrders",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTransactions_ArtGalleryUser_UserId",
                table: "BookingTransactions",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ArtGalleryUser_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsOrders_ArtGalleryUser_UserId",
                table: "EventsOrders",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleTransactions_ArtGalleryUser_UserId",
                table: "SaleTransactions",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_ArtGalleryUser_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "ArtGalleryUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
