using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatemechanicaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalProperties_Components_ComponentsComponentId",
                table: "MechanicalProperties");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalProperties_ComponentsComponentId",
                table: "MechanicalProperties");

            migrationBuilder.DropColumn(
                name: "ComponentsComponentId",
                table: "MechanicalProperties");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalProperties_ComponentId",
                table: "MechanicalProperties",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalProperties_Components_ComponentId",
                table: "MechanicalProperties",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalProperties_Components_ComponentId",
                table: "MechanicalProperties");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalProperties_ComponentId",
                table: "MechanicalProperties");

            migrationBuilder.AddColumn<int>(
                name: "ComponentsComponentId",
                table: "MechanicalProperties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalProperties_ComponentsComponentId",
                table: "MechanicalProperties",
                column: "ComponentsComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalProperties_Components_ComponentsComponentId",
                table: "MechanicalProperties",
                column: "ComponentsComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
