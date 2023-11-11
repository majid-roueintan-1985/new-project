using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class udtedrawingtorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Drawing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drawing_MechanicalEquipments_MechanicalId",
                table: "Drawing",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawing_MechanicalEquipments_MechanicalId",
                table: "Drawing");

            migrationBuilder.DropIndex(
                name: "IX_Drawing_MechanicalId",
                table: "Drawing");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Drawing");
        }
    }
}
