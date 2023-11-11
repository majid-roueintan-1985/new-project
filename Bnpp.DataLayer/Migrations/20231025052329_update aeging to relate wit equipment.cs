using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateaegingtorelatewitequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Ageing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ageing_MechanicalEquipments_MechanicalId",
                table: "Ageing",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ageing_MechanicalEquipments_MechanicalId",
                table: "Ageing");

            migrationBuilder.DropIndex(
                name: "IX_Ageing_MechanicalId",
                table: "Ageing");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Ageing");
        }
    }
}
