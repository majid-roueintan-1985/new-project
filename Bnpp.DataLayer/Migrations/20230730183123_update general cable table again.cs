using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updategeneralcabletableagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResistanceBDBAConditionFilename",
                table: "GeneralCables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResistancetoDBAConditionFilename",
                table: "GeneralCables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultFactoryTestsFilename",
                table: "GeneralCables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultTestsEndInstallationFilename",
                table: "GeneralCables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResistanceBDBAConditionFilename",
                table: "GeneralCables");

            migrationBuilder.DropColumn(
                name: "ResistancetoDBAConditionFilename",
                table: "GeneralCables");

            migrationBuilder.DropColumn(
                name: "ResultFactoryTestsFilename",
                table: "GeneralCables");

            migrationBuilder.DropColumn(
                name: "ResultTestsEndInstallationFilename",
                table: "GeneralCables");
        }
    }
}
