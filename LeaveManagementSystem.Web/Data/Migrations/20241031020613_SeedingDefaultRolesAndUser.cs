using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0af56abf-77c1-49f0-bbb0-1cf91f842414", null, "Administrator", "ADMINISTRATOR" },
                    { "472e7cb5-daff-46e1-b1c3-7b4e4b9b9286", null, "Supervisor", "SUPERVISOR" },
                    { "8efad8c1-bd44-485d-a9a5-302fe64a485e", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b8cb80f3-f899-44b9-9224-0de58b20335b", 0, "c8eca033-df3a-4be5-8dbf-dfa887d0c75e", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGElKCDI0CAvV95kETIbc0n6nbPfzjDVd+PutRqjjvJUQQQFh2mZnCyru5OG82JDQA==", null, false, "47c23076-f5c9-4484-a473-1176447ad1a6", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0af56abf-77c1-49f0-bbb0-1cf91f842414", "b8cb80f3-f899-44b9-9224-0de58b20335b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "472e7cb5-daff-46e1-b1c3-7b4e4b9b9286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8efad8c1-bd44-485d-a9a5-302fe64a485e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0af56abf-77c1-49f0-bbb0-1cf91f842414", "b8cb80f3-f899-44b9-9224-0de58b20335b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0af56abf-77c1-49f0-bbb0-1cf91f842414");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8cb80f3-f899-44b9-9224-0de58b20335b");
        }
    }
}
