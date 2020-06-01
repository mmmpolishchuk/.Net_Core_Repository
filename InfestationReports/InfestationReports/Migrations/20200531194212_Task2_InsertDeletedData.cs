using Microsoft.EntityFrameworkCore.Migrations;

namespace InfestationReports.Migrations
{
    public partial class Task2_InsertDeletedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Population", "SickCount", "DeadCount", "RecoveredCount", "Vaccine" },
                values: new object[] { 1, "USA", 328200000, 1647741, 97811, 376266, false }
            );

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 1, "Obi-wan", "Kenobi", 38, false, "Male", 1 });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 2, "Sanwise", "Gamgee", 54, false, "Male", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
