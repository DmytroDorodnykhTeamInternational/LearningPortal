using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class addteamIdcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "TeamId" },
                values: new object[] { new DateTime(2022, 8, 22, 22, 21, 49, 875, DateTimeKind.Local).AddTicks(5518), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "TeamId" },
                values: new object[] { new DateTime(2022, 8, 22, 22, 21, 49, 875, DateTimeKind.Local).AddTicks(5557), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 22, 22, 21, 49, 875, DateTimeKind.Local).AddTicks(5560));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

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
    }
}
