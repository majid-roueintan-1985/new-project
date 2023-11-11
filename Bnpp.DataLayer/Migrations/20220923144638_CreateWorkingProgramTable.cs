using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateWorkingProgramTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingPrograms",
                columns: table => new
                {
                    WorkingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasuringType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialCompositions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeldNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlPercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlStandard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QCStandard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingPrograms", x => x.WorkingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingPrograms");
        }
    }
}
