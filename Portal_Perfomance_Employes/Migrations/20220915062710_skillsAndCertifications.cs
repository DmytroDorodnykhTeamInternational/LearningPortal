using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class skillsAndCertifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Skills_SkillId",
                table: "Certifications");

            migrationBuilder.DropIndex(
                name: "IX_Certifications_SkillId",
                table: "Certifications");

            migrationBuilder.RenameColumn(
                name: "DateCertificate",
                table: "EmployeeCertifications",
                newName: "DateCertified");

            migrationBuilder.RenameColumn(
                name: "CertifcateUrl",
                table: "EmployeeCertifications",
                newName: "CertificateUrl");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Certifications",
                newName: "CertificationSkillId");

            migrationBuilder.AddColumn<int>(
                name: "CertificationSkillId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CertificationSkills",
                columns: table => new
                {
                    CertificationSkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationSkills", x => x.CertificationSkillId);
                });

            migrationBuilder.InsertData(
                table: "CertificationSkills",
                columns: new[] { "CertificationSkillId", "CertificationId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 3 },
                    { 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "CertificationId", "CertificationName", "CertificationSkillId" },
                values: new object[,]
                {
                    { 1, "AZ-301 Microsoft Azure Architect Design", 1 },
                    { 2, "70-483: Programming in C#", 2 },
                    { 3, "Cambridge English: Advanced", 3 }
                });

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
                    { 1, "Hard Skill" },
                    { 2, "Soft Skill" }
                });

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "FromDate",
                value: new DateTime(2022, 9, 15, 8, 27, 10, 41, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "SkillLevelId", "SkillLevelName", "SkillLevelTypeId" },
                values: new object[,]
                {
                    { 1, "A1", 1 },
                    { 2, "A2", 1 },
                    { 3, "B1", 1 },
                    { 4, "B2", 1 },
                    { 5, "C1", 1 },
                    { 6, "C2", 1 },
                    { 7, "Novice", 2 },
                    { 8, "Beginner", 2 },
                    { 9, "Competent", 2 },
                    { 10, "Proficient", 2 },
                    { 11, "Expert", 2 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "CertificationSkillId", "SkillLevelTypeId", "SkillName", "SkillTypeId" },
                values: new object[,]
                {
                    { 1, 0, 2, "English proficiency", 2 },
                    { 2, 0, 1, "Microsoft Azure architecture", 1 },
                    { 3, 0, 1, "C#/.NET programming", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationSkills");

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certifications",
                keyColumn: "CertificationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SkillLevels",
                keyColumn: "SkillLevelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 3);

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

            migrationBuilder.DropColumn(
                name: "CertificationSkillId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "DateCertified",
                table: "EmployeeCertifications",
                newName: "DateCertificate");

            migrationBuilder.RenameColumn(
                name: "CertificateUrl",
                table: "EmployeeCertifications",
                newName: "CertifcateUrl");

            migrationBuilder.RenameColumn(
                name: "CertificationSkillId",
                table: "Certifications",
                newName: "SkillId");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "Password", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "Password", "Role", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp11", "Test11", null, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp5", "Test5", null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp6", "Test6", null, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp7", "Test7", null, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp8", "Test8", null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp9", "Test9", null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp10", "Test10", null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp11", "Test11", null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "DateOfBirth", "EmailAddress", "FirstName", "LastName", "Password", "Role", "Seniority", "Username" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emp4", "Test4", null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "FromDate",
                value: new DateTime(2022, 9, 10, 1, 46, 34, 105, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_SkillId",
                table: "Certifications",
                column: "SkillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Skills_SkillId",
                table: "Certifications",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId");
        }
    }
}
