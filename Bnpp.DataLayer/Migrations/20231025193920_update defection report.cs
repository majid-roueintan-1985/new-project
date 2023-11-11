using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatedefectionreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "DefectionReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefectionReports_MechanicalEquipments_MechanicalId",
                table: "DefectionReports",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefectionReports_MechanicalEquipments_MechanicalId",
                table: "DefectionReports");

            migrationBuilder.DropIndex(
                name: "IX_DefectionReports_MechanicalId",
                table: "DefectionReports");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "DefectionReports");
        }
    }
}
