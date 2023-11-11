using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class newupdateforoperational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals");

            migrationBuilder.CreateIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals",
                column: "MechanicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals");

            migrationBuilder.CreateIndex(
                name: "IX_Operationals_MechanicalId",
                table: "Operationals",
                column: "MechanicalId",
                unique: true);
        }
    }
}
