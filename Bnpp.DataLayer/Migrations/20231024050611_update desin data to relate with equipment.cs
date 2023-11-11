using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatedesindatatorelatewithequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MechanicalId",
                table: "DesignData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData",
                column: "MechanicalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignData_MechanicalEquipments_MechanicalId",
                table: "DesignData",
                column: "MechanicalId",
                principalTable: "MechanicalEquipments",
                principalColumn: "MechanicalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignData_MechanicalEquipments_MechanicalId",
                table: "DesignData");

            migrationBuilder.DropIndex(
                name: "IX_DesignData_MechanicalId",
                table: "DesignData");

            migrationBuilder.DropColumn(
                name: "MechanicalId",
                table: "DesignData");
        }
    }
}
