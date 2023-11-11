using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateeventagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationalOrganization",
                table: "Events",
                newName: "RelatedAgeingMechanism");

            migrationBuilder.RenameColumn(
                name: "EventReasons",
                table: "Events",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedAgeingMechanism",
                table: "Events",
                newName: "OperationalOrganization");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "EventReasons");
        }
    }
}
