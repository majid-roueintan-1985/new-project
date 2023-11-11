using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class UpdateDamageabilityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllowableCUF",
                table: "DamageabilityReports",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AllowableLifeTime",
                table: "DamageabilityReports",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChangingRatio",
                table: "DamageabilityReports",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowableCUF",
                table: "DamageabilityReports");

            migrationBuilder.DropColumn(
                name: "AllowableLifeTime",
                table: "DamageabilityReports");

            migrationBuilder.DropColumn(
                name: "ChangingRatio",
                table: "DamageabilityReports");
        }
    }
}
