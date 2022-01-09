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
                values: new object[] { "5b604f61-e30f-4307-bea5-7365d61cb7c6", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "28111b36-1030-4e0f-898b-2af46098a355", null, "admin@ehb.be", true, true, null, "ADMIN@EHB.BE", "ADMIN", "AQAAAAEAACcQAAAAED+Y/MGaT1oxoqQuUBbX7yDct5O6IukzYoX13P/qPFPCNi7YTeA9G1J1w9V5KIIyNQ==", null, false, "6X3AIBHQ7VN3WINUXRQYDXA3OJ33UOQU", false, "Admin" });

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
                keyValue: "5b604f61-e30f-4307-bea5-7365d61cb7c6");

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
