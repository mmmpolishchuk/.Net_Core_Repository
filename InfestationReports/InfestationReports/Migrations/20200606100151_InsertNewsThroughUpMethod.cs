using Microsoft.EntityFrameworkCore.Migrations;

namespace InfestationReports.Migrations
{
    public partial class InsertNewsThroughUpMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                values: new object[] { 1, "Humanity finally colonized the Mercury!!", "", true, 3 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                values: new object[] { 2, "Increase your lifespan by 10 years, every morning you need...", "", true, 6 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                values: new object[] { 3, "Scientists estimated the time of the vaccine invention: it is a summer of 2021", "", false, 6 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                values: new object[] { 4, "Ukraine reduces the cost of its obligations!", "", false, 5 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
                values: new object[] { 5, "A new species were discovered in Africa: it is blue legless cat", "", true, 9 });
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
