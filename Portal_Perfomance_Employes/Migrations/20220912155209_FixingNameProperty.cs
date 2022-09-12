using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class FixingNameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCertified",
                table: "EmployeeCertifications",
                newName: "DateCertificate");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 52, 9, 611, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 52, 9, 611, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 52, 9, 611, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 12, 16, 52, 9, 611, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 12, 16, 52, 9, 611, DateTimeKind.Local).AddTicks(90));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCertificate",
                table: "EmployeeCertifications",
                newName: "DateCertified");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 36, 51, 716, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 36, 51, 716, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 12, 16, 36, 51, 716, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 12, 16, 36, 51, 716, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 12, 16, 36, 51, 716, DateTimeKind.Local).AddTicks(6189));
        }
    }
}
