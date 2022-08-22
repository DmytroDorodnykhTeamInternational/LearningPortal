using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class renamecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tier",
                table: "Employees",
                newName: "Seniority");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Employees",
                newName: "Role");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 22, 14, 2, 37, 876, DateTimeKind.Local).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 22, 14, 2, 37, 876, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 22, 14, 2, 37, 876, DateTimeKind.Local).AddTicks(6771));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seniority",
                table: "Employees",
                newName: "Tier");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Employees",
                newName: "Level");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 19, 19, 47, 43, 82, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 19, 19, 47, 43, 82, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 19, 19, 47, 43, 82, DateTimeKind.Local).AddTicks(6881));
        }
    }
}
