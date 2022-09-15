using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class uppendSkillsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.InsertData(
                table: "SkillLevelTypes",
                columns: new[] { "SkillLevelTypeId", "SkillLevelTypeName" },
                values: new object[,]
                {
                    { 1, "Language" },
                    { 2, "Technology" }
                });

            migrationBuilder.InsertData(
                table: "SkillTypes",
                columns: new[] { "SkillTypeId", "SkillTypeName" },
                values: new object[,]
                {
                    { 1, "Soft skill" },
                    { 2, "Hard skill" }
                });

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 18, 58, 7, 635, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "SkillLevelId", "SkillLevelName", "SkillLevelTypeId" },
                values: new object[,]
                {
                    { 1, "B1", 1 },
                    { 2, "Advanced", 2 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillLevelTypeId", "SkillName", "SkillTypeId" },
                values: new object[,]
                {
                    { 1, 1, "Spoken English", 1 },
                    { 2, 2, "C# Programming", 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "SkillId", "SkillLevelId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "SkillId", "SkillLevelId" },
                values: new object[] { 2, 1, 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkillLevelTypes",
                keyColumn: "SkillLevelTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillLevelTypes",
                keyColumn: "SkillLevelTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkillTypes",
                keyColumn: "SkillTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillTypes",
                keyColumn: "SkillTypeId",
                keyValue: 2);

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
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7298));

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

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "FromDate",
                value: new DateTime(2022, 9, 13, 15, 50, 31, 653, DateTimeKind.Local).AddTicks(7383));
        }
    }
}
