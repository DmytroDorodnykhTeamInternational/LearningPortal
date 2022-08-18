using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class schemaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 42, 24, 610, DateTimeKind.Local).AddTicks(4540), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emp1", "Test1" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 42, 24, 610, DateTimeKind.Local).AddTicks(4569), new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emp2", "Test2" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new DateTime(2022, 8, 18, 15, 42, 24, 610, DateTimeKind.Local).AddTicks(4571), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emp3", "Test3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Created", "Name" },
                values: new object[] { 25, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(8957), "Emp1" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Created", "Name" },
                values: new object[] { 30, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(8997), "Emp2" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "Created", "Name" },
                values: new object[] { 35, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(9000), "Emp3" });
        }
    }
}
