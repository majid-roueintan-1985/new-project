using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Transient
{
    public partial class updatetransientAgaain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllowableNumber",
                table: "Transients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowableNumber",
                table: "Transients");
        }
    }
}
