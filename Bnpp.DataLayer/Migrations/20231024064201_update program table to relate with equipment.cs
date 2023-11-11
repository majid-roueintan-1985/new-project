using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateprogramtabletorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "InspectionPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionPrograms_MechanicalEquipments_MechanicalId",
                table: "InspectionPrograms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionPrograms_MechanicalEquipments_MechanicalId",
                table: "InspectionPrograms");

            migrationBuilder.DropIndex(
                name: "IX_InspectionPrograms_MechanicalId",
                table: "InspectionPrograms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "InspectionPrograms");
        }
    }
}
