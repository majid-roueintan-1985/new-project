using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatemeasurmenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_MechanicalEquipments_MechanicalId",
                table: "Measurements",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_MechanicalEquipments_MechanicalId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_MechanicalId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Measurements");
        }
    }
}
