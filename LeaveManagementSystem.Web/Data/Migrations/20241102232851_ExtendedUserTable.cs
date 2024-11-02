using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8cb80f3-f899-44b9-9224-0de58b20335b",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cacffed-fe66-46b5-9bfd-245874f81ec6", new DateOnly(1900, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAENzJDxvdDqA63rQphGbbaeyCLkxEupos4przPpY14lv2/2OC6DHs29b2GaFDxfer4w==", "3661b238-c38a-43ca-b83e-c8e41e31d29d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8cb80f3-f899-44b9-9224-0de58b20335b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8eca033-df3a-4be5-8dbf-dfa887d0c75e", "AQAAAAIAAYagAAAAEGElKCDI0CAvV95kETIbc0n6nbPfzjDVd+PutRqjjvJUQQQFh2mZnCyru5OG82JDQA==", "47c23076-f5c9-4484-a473-1176447ad1a6" });
        }
    }
}
