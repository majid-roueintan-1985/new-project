using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateChemicalComponenets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChemicalComponents",
                columns: table => new
                {
                    ChemicalComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Si = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    As = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Co = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalComponents", x => x.ChemicalComponentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalComponents");
        }
    }
}
