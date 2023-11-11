using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatesparelist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "SpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_MechanicalEquipments_MechanicalId",
                table: "SpareParts",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_MechanicalEquipments_MechanicalId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_MechanicalId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "SpareParts");
        }
    }
}
