using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class insertmorefieldtocomponenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "As",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "C",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Co",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConductivityFactor",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoolingMethod",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cr",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cu",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Density",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNo",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hardness",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeatCapacity",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeatsOperation",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImpactToughness",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinearExpension",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MechanicalTemperature",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mn",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mo",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NB",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ni",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoOfHeatOperations",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalRadiation",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "P",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhysicalTemperature",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PoissonRatio",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReductionArea",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "S",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Si",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecificElongation",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ti",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TreatmentTemperature",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UltimateStrength",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "V",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YieldStrength",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YoungModule",
                table: "Components",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "As",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "C",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Co",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ConductivityFactor",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "CoolingMethod",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Cr",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Cu",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Density",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "DocumentNo",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Hardness",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "HeatCapacity",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "HeatsOperation",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ImpactToughness",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "LinearExpension",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "MechanicalTemperature",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Mn",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Mo",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "NB",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Ni",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "NoOfHeatOperations",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "NormalRadiation",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "P",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "PhysicalTemperature",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "PoissonRatio",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ReductionArea",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "S",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Si",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "SpecificElongation",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "Ti",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "TreatmentTemperature",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "UltimateStrength",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "V",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "YieldStrength",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "YoungModule",
                table: "Components");
        }
    }
}
