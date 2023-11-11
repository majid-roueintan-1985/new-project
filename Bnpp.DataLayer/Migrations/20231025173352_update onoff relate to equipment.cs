using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateonoffrelatetoequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "ChangeState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeState_MechanicalEquipments_MechanicalId",
                table: "ChangeState",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeState_MechanicalEquipments_MechanicalId",
                table: "ChangeState");

            migrationBuilder.DropIndex(
                name: "IX_ChangeState_MechanicalId",
                table: "ChangeState");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "ChangeState");
        }
    }
}
