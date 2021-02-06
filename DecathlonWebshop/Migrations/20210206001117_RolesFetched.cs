using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DecathlonWebshop.Migrations
{
    public partial class RolesFetched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09036a82 - 6e96 - 4c74 - b521 - 760131a784aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "fb8ec3dd-6d0f-49bf-b30b-f08aa8736e39", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad3431de-eaa8-4c97-a1e2-1b45a6a76bb9", "0285a836-77a4-4b71-810f-151f81f5b43d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09036a82-6e96-4c74-b521-760131a784aa", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4ce14a80-bb0d-4167-8b27-b0ebedb497e8", null, "admin@ehb.be", false, true, null, "ADMIN@EHB.BE", "ADMIN", "AQAAAAEAACcQAAAAEJCH3PqMTk/hWAYggJmdC/MhNeVG21iE80PLJb+WWKpzGKLkzQp3hqt2GJus8je0ZA==", null, false, "BXBND3XBXLJ2QQVYGXYF7KQKW3ZQKAD2", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "09036a82-6e96-4c74-b521-760131a784aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3431de-eaa8-4c97-a1e2-1b45a6a76bb9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "09036a82-6e96-4c74-b521-760131a784aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980496f5-b4f2-4975-8e7f-cec5d2e001ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09036a82-6e96-4c74-b521-760131a784aa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09036a82 - 6e96 - 4c74 - b521 - 760131a784aa", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4ce14a80-bb0d-4167-8b27-b0ebedb497e8", null, "admin@ehb.be", false, true, null, "ADMIN@EHB.BE", "ADMIN", "AQAAAAEAACcQAAAAEJCH3PqMTk/hWAYggJmdC/MhNeVG21iE80PLJb+WWKpzGKLkzQp3hqt2GJus8je0ZA==", null, false, "BXBND3XBXLJ2QQVYGXYF7KQKW3ZQKAD2", false, "Admin" });
        }
    }
}
