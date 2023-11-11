using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updategeneraldatatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "GeneralData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralData_MechanicalEquipments_MechanicalId",
                table: "GeneralData",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralData_MechanicalEquipments_MechanicalId",
                table: "GeneralData");

            migrationBuilder.DropIndex(
                name: "IX_GeneralData_MechanicalId",
                table: "GeneralData");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "GeneralData");
        }
    }
}
