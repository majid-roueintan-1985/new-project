using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Transient
{
    public partial class newupdateoftransienttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransientFileName",
                table: "Transients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransientFileName",
                table: "Transients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
