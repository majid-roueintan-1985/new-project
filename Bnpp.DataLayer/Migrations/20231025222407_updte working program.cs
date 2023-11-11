using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updteworkingprogram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "WorkingPrograms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingPrograms_MechanicalEquipments_MechanicalId",
                table: "WorkingPrograms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingPrograms_MechanicalEquipments_MechanicalId",
                table: "WorkingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_WorkingPrograms_MechanicalId",
                table: "WorkingPrograms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "WorkingPrograms");
        }
    }
}
