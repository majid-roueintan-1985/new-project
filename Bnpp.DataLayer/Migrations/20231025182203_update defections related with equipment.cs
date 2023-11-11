using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatedefectionsrelatedwithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "DefectList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefectList_MechanicalEquipments_MechanicalId",
                table: "DefectList",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefectList_MechanicalEquipments_MechanicalId",
                table: "DefectList");

            migrationBuilder.DropIndex(
                name: "IX_DefectList_MechanicalId",
                table: "DefectList");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "DefectList");
        }
    }
}
