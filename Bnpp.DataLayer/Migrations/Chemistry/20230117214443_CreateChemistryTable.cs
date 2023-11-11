using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Chemistry
{
    public partial class CreateChemistryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChemistryTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    System = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SamplingPoint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Building = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SystemStateCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CircuitCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExperimentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParameterCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UnitCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ComparisonWithNormalValueSymbol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NormalValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ComparisonWithNormalValueSymbol2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NormalValue2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExecutingScheduleCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NoteCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemistryTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemistryTable");
        }
    }
}
