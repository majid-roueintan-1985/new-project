using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateeventstorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_MechanicalId",
                table: "Events",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_MechanicalEquipments_MechanicalId",
                table: "Events",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_MechanicalEquipments_MechanicalId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_MechanicalId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "Events");
        }
    }
}
