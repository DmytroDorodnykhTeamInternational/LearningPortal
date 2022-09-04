using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class removeTeamIdfromEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4962));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "TeamId" },
                values: new object[] { new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7078), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "TeamId" },
                values: new object[] { new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7121), 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7144));
        }
    }
}
