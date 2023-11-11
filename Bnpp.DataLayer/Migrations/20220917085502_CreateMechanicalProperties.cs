using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateMechanicalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicalProperties",
                columns: table => new
                {
                    MechanicalPropertiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoungModule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YieldStrength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimateStrength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificElongation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReductionArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpactToughness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hardness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ComponentsComponentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalProperties", x => x.MechanicalPropertiesId);
                    table.ForeignKey(
                        name: "FK_MechanicalProperties_Components_ComponentsComponentId",
                        column: x => x.ComponentsComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalProperties_ComponentsComponentId",
                table: "MechanicalProperties",
                column: "ComponentsComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicalProperties");
        }
    }
}
