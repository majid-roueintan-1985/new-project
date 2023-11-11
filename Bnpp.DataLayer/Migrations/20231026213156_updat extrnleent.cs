using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatextrnleent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "ExternalEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalEvents_MechanicalEquipments_MechanicalId",
                table: "ExternalEvents",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalEvents_MechanicalEquipments_MechanicalId",
                table: "ExternalEvents");

            migrationBuilder.DropIndex(
                name: "IX_ExternalEvents_MechanicalId",
                table: "ExternalEvents");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "ExternalEvents");
        }
    }
}
