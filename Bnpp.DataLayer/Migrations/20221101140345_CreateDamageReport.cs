using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateDamageReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DamageabilityReports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Totaldamageabilityofequipment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Damageabilityperuncoiledcycles = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Damageabilitypercoiledcycles = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LifetimeofequipmentperRALDS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Lifetimeofequipmentindesign = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Actionperiodofequipment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Locationofthecheckpoint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageabilityReports", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamageabilityReports");
        }
    }
}
