using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateinstalationtorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Installation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Installation_MechanicalEquipments_MechanicalId",
                table: "Installation",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Installation_MechanicalEquipments_MechanicalId",
                table: "Installation");

            migrationBuilder.DropIndex(
                name: "IX_Installation_MechanicalId",
                table: "Installation");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Installation");
        }
    }
}
