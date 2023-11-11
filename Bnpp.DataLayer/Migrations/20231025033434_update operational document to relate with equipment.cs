using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updateoperationaldocumenttorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "OperationalDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationalDocuments_MechanicalEquipments_MechanicalId",
                table: "OperationalDocuments",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationalDocuments_MechanicalEquipments_MechanicalId",
                table: "OperationalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_OperationalDocuments_MechanicalId",
                table: "OperationalDocuments");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "OperationalDocuments");
        }
    }
}
