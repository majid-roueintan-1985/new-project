using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_MechanicalId",
                table: "TestResults",
                column: "MechanicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_MechanicalEquipments_MechanicalId",
                table: "TestResults",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_MechanicalEquipments_MechanicalId",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_MechanicalId",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "TestResults");
        }
    }
}
