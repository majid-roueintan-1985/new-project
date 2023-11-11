using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateGeneralCablesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralCables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableIDGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeofCable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassificationofCable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsulationMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JacketMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntermediateLocations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberofSimilarCables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLengthofSimilarCables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedDegradationMechanisms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesignLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingDesignLifeTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NominalCurrent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingAmbientTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResistancetoDBAConditionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResistanceBDBAConditionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultFactoryTestsImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultTestsEndInstallationImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCables", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralCables");
        }
    }
}
