using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class upaeeigndocumenttorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "DesignDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignDocuments_MechanicalEquipments_MechanicalId",
                table: "DesignDocuments",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignDocuments_MechanicalEquipments_MechanicalId",
                table: "DesignDocuments");

            migrationBuilder.DropIndex(
                name: "IX_DesignDocuments_MechanicalId",
                table: "DesignDocuments");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "DesignDocuments");
        }
    }
}
