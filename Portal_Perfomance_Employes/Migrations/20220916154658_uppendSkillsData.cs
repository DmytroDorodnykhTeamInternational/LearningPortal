using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class uppendSkillsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "Username" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2256), new DateTime(1987, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp2@email.com", "Emp4", "Test4", "1234", 0, 0, "emp2" },
                    { 5, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2259), new DateTime(1988, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp3@email.com", "Emp5", "Test5", "1234", 0, 1, "emp3" },
                    { 6, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2261), new DateTime(2001, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp4@email.com", "Emp6", "Test6", "1234", 0, 1, "emp4" },
                    { 7, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2264), new DateTime(2003, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp5@email.com", "Emp7", "Test7", "1234", 0, 0, "emp5" },
                    { 8, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2266), new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp6@email.com", "Emp8", "Test8", "1234", 1, 1, "emp6" },
                    { 9, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2269), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp7@email.com", "Emp9", "Test9", "1234", 2, 2, "emp7" },
                    { 10, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2272), new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emp8@email.com", "Emp10", "Test10", "1234", 0, 0, "emp8" },
                    { 11, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2274), new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "teamlead2@email.com", "Emp11", "Test11", "1234", 1, 1, "teamlead2" },
                    { 12, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2277), new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin2@email.com", "Emp12", "Test12", "1234", 2, 2, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "DateCreated", "TeamLeaderId", "TeamName" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Team number two" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "EmployeeId", "FirstName", "FromDate", "IsActive", "LastName", "TeamId", "ToDate" },
                values: new object[,]
                {
                    { 3, 11, "Emp11", new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Test11", 1, new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2304) },
                    { 4, 5, "Emp5", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2306), true, "Test5", 1, null },
                    { 5, 6, "Emp6", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2308), true, "Test6", 1, null },
                    { 6, 7, "Emp7", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2310), true, "Test7", 2, null },
                    { 7, 8, "Emp8", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2312), true, "Test8", 2, null },
                    { 8, 9, "Emp9", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2314), true, "Test9", 2, null },
                    { 9, 10, "Emp10", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2316), true, "Test10", 2, null },
                    { 10, 11, "Emp11", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2318), true, "Test11", 2, null },
                    { 11, 4, "Emp4", new DateTime(2022, 9, 16, 18, 46, 58, 316, DateTimeKind.Local).AddTicks(2320), true, "Test4", 2, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "SkillId", "SkillLevelId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "SkillId", "SkillLevelId" },
                values: new object[] { 2, 1, 2, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCertifications");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SkillLevelTypes");

            migrationBuilder.DropTable(
                name: "SkillTypes");
        }
    }
}
