using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateingmechanismdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "MechanismDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MechanismDocuments_MechanicalEquipments_MechanicalId",
                table: "MechanismDocuments",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanismDocuments_MechanicalEquipments_MechanicalId",
                table: "MechanismDocuments");

            migrationBuilder.DropIndex(
                name: "IX_MechanismDocuments_MechanicalId",
                table: "MechanismDocuments");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "MechanismDocuments");
        }
    }
}
