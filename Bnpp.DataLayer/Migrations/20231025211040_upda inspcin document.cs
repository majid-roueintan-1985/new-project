using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updainspcindocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "InspectionDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDocuments_MechanicalId",
                table: "InspectionDocuments",
                column: "MechanicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionDocuments_MechanicalEquipments_MechanicalId",
                table: "InspectionDocuments",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionDocuments_MechanicalEquipments_MechanicalId",
                table: "InspectionDocuments");

            migrationBuilder.DropIndex(
                name: "IX_InspectionDocuments_MechanicalId",
                table: "InspectionDocuments");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "InspectionDocuments");
        }
    }
}
