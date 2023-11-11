using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateesrorlatdwithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Sensors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_MechanicalEquipments_MechanicalId",
                table: "Sensors",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_MechanicalEquipments_MechanicalId",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_MechanicalId",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Sensors");
        }
    }
}
