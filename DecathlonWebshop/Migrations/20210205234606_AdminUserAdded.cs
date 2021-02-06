using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DecathlonWebshop.Migrations
{
    public partial class AdminUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09036a82 - 6e96 - 4c74 - b521 - 760131a784aa", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4ce14a80-bb0d-4167-8b27-b0ebedb497e8", null, "admin@ehb.be", false, true, null, "ADMIN@EHB.BE", "ADMIN", "AQAAAAEAACcQAAAAEJCH3PqMTk/hWAYggJmdC/MhNeVG21iE80PLJb+WWKpzGKLkzQp3hqt2GJus8je0ZA==", null, false, "BXBND3XBXLJ2QQVYGXYF7KQKW3ZQKAD2", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Peach Pie");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Pumpkin Pie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09036a82 - 6e96 - 4c74 - b521 - 760131a784aa");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Peach Product");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Pumpkin Product");
        }
    }
}
