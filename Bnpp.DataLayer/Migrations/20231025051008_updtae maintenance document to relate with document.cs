using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updtaemaintenancedocumenttorelatewithdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "MaintenanceDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDocument_MechanicalEquipments_MechanicalId",
                table: "MaintenanceDocument",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDocument_MechanicalEquipments_MechanicalId",
                table: "MaintenanceDocument");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDocument_MechanicalId",
                table: "MaintenanceDocument");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "MaintenanceDocument");
        }
    }
}
