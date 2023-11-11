using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateinstallationrelatetoequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Commissioning",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commissioning_MechanicalEquipments_MechanicalId",
                table: "Commissioning",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commissioning_MechanicalEquipments_MechanicalId",
                table: "Commissioning");

            migrationBuilder.DropIndex(
                name: "IX_Commissioning_MechanicalId",
                table: "Commissioning");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Commissioning");
        }
    }
}
