using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class uptcnropntstorelattwithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "ControlPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPoints_MechanicalEquipments_MechanicalId",
                table: "ControlPoints",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPoints_MechanicalEquipments_MechanicalId",
                table: "ControlPoints");

            migrationBuilder.DropIndex(
                name: "IX_ControlPoints_MechanicalId",
                table: "ControlPoints");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "ControlPoints");
        }
    }
}
