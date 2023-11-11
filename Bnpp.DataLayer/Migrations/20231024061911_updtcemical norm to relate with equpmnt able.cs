using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updtcemicalnormtorelatewithequpmntable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "ChemicalNorms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalNorms_MechanicalEquipments_MechanicalId",
                table: "ChemicalNorms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalNorms_MechanicalEquipments_MechanicalId",
                table: "ChemicalNorms");

            migrationBuilder.DropIndex(
                name: "IX_ChemicalNorms_MechanicalId",
                table: "ChemicalNorms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "ChemicalNorms");
        }
    }
}
