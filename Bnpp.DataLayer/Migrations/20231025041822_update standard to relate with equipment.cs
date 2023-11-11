using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatestandardtorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Standard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Standard_MechanicalEquipments_MechanicalId",
                table: "Standard",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standard_MechanicalEquipments_MechanicalId",
                table: "Standard");

            migrationBuilder.DropIndex(
                name: "IX_Standard_MechanicalId",
                table: "Standard");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Standard");
        }
    }
}
