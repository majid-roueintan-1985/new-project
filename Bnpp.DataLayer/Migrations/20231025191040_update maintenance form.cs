using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatemaintenanceform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "MaintenanceForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceForms_MechanicalEquipments_MechanicalId",
                table: "MaintenanceForms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceForms_MechanicalEquipments_MechanicalId",
                table: "MaintenanceForms");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceForms_MechanicalId",
                table: "MaintenanceForms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "MaintenanceForms");
        }
    }
}
