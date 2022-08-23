using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 8, 23, 14, 11, 43, 878, DateTimeKind.Local).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 8, 23, 14, 11, 43, 878, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 8, 23, 14, 11, 43, 878, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Created", "EmailAddress", "GivenName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 23, 14, 11, 43, 878, DateTimeKind.Local).AddTicks(9177), "admin@email.com", "adm", "1234", 2, "admin" },
                    { 2, new DateTime(2022, 8, 23, 14, 11, 43, 878, DateTimeKind.Local).AddTicks(9181), "emp@email.com", "emp", "1234", 0, "emp" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

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
