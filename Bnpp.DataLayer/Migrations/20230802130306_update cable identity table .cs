using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatecableidentitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CableIdentities_CableGroups_CableGroupGroupId",
                table: "CableIdentities");

            migrationBuilder.DropIndex(
                name: "IX_CableIdentities_CableGroupGroupId",
                table: "CableIdentities");

            migrationBuilder.DropColumn(
                name: "CableGroupGroupId",
                table: "CableIdentities");

            migrationBuilder.CreateIndex(
                name: "IX_CableIdentities_GroupId",
                table: "CableIdentities",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CableIdentities_CableGroups_GroupId",
                table: "CableIdentities",
                column: "GroupId",
                principalTable: "CableGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CableIdentities_CableGroups_GroupId",
                table: "CableIdentities");

            migrationBuilder.DropIndex(
                name: "IX_CableIdentities_GroupId",
                table: "CableIdentities");

            migrationBuilder.AddColumn<int>(
                name: "CableGroupGroupId",
                table: "CableIdentities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CableIdentities_CableGroupGroupId",
                table: "CableIdentities",
                column: "CableGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CableIdentities_CableGroups_CableGroupGroupId",
                table: "CableIdentities",
                column: "CableGroupGroupId",
                principalTable: "CableGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
