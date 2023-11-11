using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class udehfrmstorelatedwithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "HForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HForms_MechanicalEquipments_MechanicalId",
                table: "HForms",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HForms_MechanicalEquipments_MechanicalId",
                table: "HForms");

            migrationBuilder.DropIndex(
                name: "IX_HForms_MechanicalId",
                table: "HForms");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "HForms");
        }
    }
}
