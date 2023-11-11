using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CrateTypicaProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypicalPrograms",
                columns: table => new
                {
                    TypicalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestStandard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlPercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypicalPrograms", x => x.TypicalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypicalPrograms");
        }
    }
}
