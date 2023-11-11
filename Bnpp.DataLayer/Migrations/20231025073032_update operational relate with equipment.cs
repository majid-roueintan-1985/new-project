using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateoperationalrelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Operationals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operationals_MechanicalEquipments_MechanicalId",
                table: "Operationals",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operationals_MechanicalEquipments_MechanicalId",
                table: "Operationals");

            migrationBuilder.DropIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Operationals");
        }
    }
}
