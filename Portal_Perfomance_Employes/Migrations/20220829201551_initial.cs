using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class initial : Migration
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
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamLeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "TeamId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7078), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp@email.com", "Emp1", "Test1", "1234", 0, 0, 1, "emp" },
                    { 2, new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7121), new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "teamlead@email.com", "Emp2", "Test2", "1234", 1, 1, 1, "teamlead" },
                    { 3, new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7123), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@email.com", "Emp3", "Test3", "1234", 2, 2, null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "EmployeeId", "FirstName", "FromDate", "IsActive", "LastName", "TeamId", "ToDate" },
                values: new object[,]
                {
                    { 1, 1, "Emp1", new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7139), true, "Test1", 1, null },
                    { 2, 2, "Emp2", new DateTime(2022, 8, 29, 22, 15, 51, 350, DateTimeKind.Local).AddTicks(7144), true, "Test2", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "DateCreated", "TeamLeaderId", "TeamName" },
                values: new object[] { 1, new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Team number one" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
