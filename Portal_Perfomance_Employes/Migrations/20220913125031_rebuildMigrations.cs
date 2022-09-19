using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class rebuildMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7365));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 49, 6, 255, DateTimeKind.Local).AddTicks(1974));
        }
    }
}
