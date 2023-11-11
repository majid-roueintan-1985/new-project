using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatecomponenttorelateequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Components_MechanicalId",
                table: "Components",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MechanicalEquipments_MechanicalId",
                table: "Components",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_MechanicalEquipments_MechanicalId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_MechanicalId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Components");
        }
    }
}
