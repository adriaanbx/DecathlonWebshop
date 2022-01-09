using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DecathlonWebshop.Migrations
{
    public partial class RolesFetched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "fb8ec3dd-6d0f-49bf-b30b-f08aa8736e39", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad3431de-eaa8-4c97-a1e2-1b45a6a76bb9", "0285a836-77a4-4b71-810f-151f81f5b43d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "5b604f61-e30f-4307-bea5-7365d61cb7c6" });
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
                keyValues: new object[] { "980496f5-b4f2-4975-8e7f-cec5d2e001ab", "5b604f61-e30f-4307-bea5-7365d61cb7c6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980496f5-b4f2-4975-8e7f-cec5d2e001ab");

        }
    }
}
