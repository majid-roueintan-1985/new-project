using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CretePhysicalPropertiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysicalProperties",
                columns: table => new
                {
                    PhysicalPropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinearExpension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeatCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConductivityFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalRadiation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoissonRatio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Density = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalProperties", x => x.PhysicalPropertiesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalProperties");
        }
    }
}
