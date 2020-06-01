using Microsoft.EntityFrameworkCore.Migrations;

namespace InfestationReports.Migrations
{
    public partial class Task21_InsertDataThroughUpMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Population", "SickCount", "DeadCount", "RecoveredCount", "Vaccine" },
                values: new object[] { 4, "Ukraine", 42000000, 23672, 708, 9538, false });
            
            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 8, "Petro", "Shevchenko", 71, true, "Male", 4 });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 9, "Oleh", "Ivanov", 49, false, "Male", 3 });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 10, "Alla", "Chernyak", 53, true, "Female", 4 });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 11, "Ihor", "Syzyi", 13, true, "Male", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
