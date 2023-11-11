using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class Createtestresult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestResultsType",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TypeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultsType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    TestResultsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeldNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeldSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestScope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundDefectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NooflogBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionofWeld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthofSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sensitivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevealedDefects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionsofUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumAllowed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasuredThickness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumAllowedThickness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.TestResultsId);
                    table.ForeignKey(
                        name: "FK_TestResults_TestResultsType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TestResultsType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TypeId",
                table: "TestResults",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "TestResultsType");
        }
    }
}
