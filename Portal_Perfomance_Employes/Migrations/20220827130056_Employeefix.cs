using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class Employeefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seniority = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "TeamId", "Username" },
                values: new object[] { 1, new DateTime(2022, 8, 27, 14, 0, 56, 403, DateTimeKind.Local).AddTicks(665), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp@email.com", "Emp1", "Test1", "1234", 0, 0, 2, "emp" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "TeamId", "Username" },
                values: new object[] { 2, new DateTime(2022, 8, 27, 14, 0, 56, 403, DateTimeKind.Local).AddTicks(697), new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "teamlead@email.com", "Emp2", "Test2", "1234", 1, 1, 2, "teamlead" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "TeamId", "Username" },
                values: new object[] { 3, new DateTime(2022, 8, 27, 14, 0, 56, 403, DateTimeKind.Local).AddTicks(700), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@email.com", "Emp3", "Test3", "1234", 2, 2, 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
