using Microsoft.EntityFrameworkCore.Migrations;

namespace InfestationReports.Migrations
{
    public partial class EditNewsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Humans_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "Humans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Humans_AuthorId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_AuthorId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
