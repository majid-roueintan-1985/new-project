using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CretaeDefectlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefectList",
                columns: table => new
                {
                    DefectListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructionCorrection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlCorrection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlInstructionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartorEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameofDefect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectList", x => x.DefectListId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectList");
        }
    }
}
