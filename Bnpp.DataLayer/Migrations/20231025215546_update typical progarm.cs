using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatetypicalprogarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "TypicalPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypicalPrograms_MechanicalId",
                table: "TypicalPrograms",
                column: "MechanicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypicalPrograms_MechanicalEquipments_MechanicalId",
                table: "TypicalPrograms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypicalPrograms_MechanicalEquipments_MechanicalId",
                table: "TypicalPrograms");

            migrationBuilder.DropIndex(
                name: "IX_TypicalPrograms_MechanicalId",
                table: "TypicalPrograms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "TypicalPrograms");
        }
    }
}
