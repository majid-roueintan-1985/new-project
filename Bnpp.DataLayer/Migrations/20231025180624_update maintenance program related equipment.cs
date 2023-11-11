using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatemaintenanceprogramrelatedequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "MaintenancePrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancePrograms_MechanicalEquipments_MechanicalId",
                table: "MaintenancePrograms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancePrograms_MechanicalEquipments_MechanicalId",
                table: "MaintenancePrograms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancePrograms_MechanicalId",
                table: "MaintenancePrograms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "MaintenancePrograms");
        }
    }
}
