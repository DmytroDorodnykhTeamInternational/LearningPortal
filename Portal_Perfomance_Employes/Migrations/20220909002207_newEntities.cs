using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class newEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillLevelType",
                columns: table => new
                {
                    SkillLevelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillLevelTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevelType", x => x.SkillLevelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SkillType",
                columns: table => new
                {
                    SkillTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillType", x => x.SkillTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevel",
                columns: table => new
                {
                    SkillLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillLevelTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevel", x => x.SkillLevelId);
                    table.ForeignKey(
                        name: "FK_SkillLevel_SkillLevelType_SkillLevelTypeId",
                        column: x => x.SkillLevelTypeId,
                        principalTable: "SkillLevelType",
                        principalColumn: "SkillLevelTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillLevelTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillTypeId = table.Column<int>(type: "int", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skill_SkillLevelType_SkillLevelTypeId",
                        column: x => x.SkillLevelTypeId,
                        principalTable: "SkillLevelType",
                        principalColumn: "SkillLevelTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skill_SkillType_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "SkillType",
                        principalColumn: "SkillTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    CertificationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.CertificationId);
                    table.ForeignKey(
                        name: "FK_Certification_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_SkillLevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevel",
                        principalColumn: "SkillLevelId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertifcateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCertification_Certification_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certification",
                        principalColumn: "CertificationId");
                    table.ForeignKey(
                        name: "FK_EmployeeCertification_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FromDate",
                value: new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FromDate",
                value: new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_EmployeeId",
                table: "TeamMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_SkillId",
                table: "Certification",
                column: "SkillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertification_CertificationId",
                table: "EmployeeCertification",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertification_EmployeeId",
                table: "EmployeeCertification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillId",
                table: "EmployeeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillLevelId",
                table: "EmployeeSkill",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillLevelTypeId",
                table: "Skill",
                column: "SkillLevelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillTypeId",
                table: "Skill",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevel_SkillLevelTypeId",
                table: "SkillLevel",
                column: "SkillLevelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Employees_EmployeeId",
                table: "TeamMembers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Employees_EmployeeId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropTable(
                name: "EmployeeCertification");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "SkillLevel");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "SkillLevelType");

            migrationBuilder.DropTable(
                name: "SkillType");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_EmployeeId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers");

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
    }
}
