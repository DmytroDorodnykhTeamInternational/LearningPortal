using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Created", "Level", "Name" },
                values: new object[] { 1, 25, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(8957), 0, "Emp1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Created", "Level", "Name" },
                values: new object[] { 2, 30, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(8997), 1, "Emp2" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Created", "Level", "Name" },
                values: new object[] { 3, 35, new DateTime(2022, 8, 17, 12, 28, 47, 670, DateTimeKind.Local).AddTicks(9000), 2, "Emp3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
