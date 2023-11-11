using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatemechanismrelatetoequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Mechanism",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mechanism_MechanicalEquipments_MechanicalId",
                table: "Mechanism",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mechanism_MechanicalEquipments_MechanicalId",
                table: "Mechanism");

            migrationBuilder.DropIndex(
                name: "IX_Mechanism_MechanicalId",
                table: "Mechanism");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Mechanism");
        }
    }
}
