using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class createoperatingcabletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperatingCableDatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableIDGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeofOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKZofTemperatureSensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureSensorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureSensorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKZofRadiationSensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiationSensorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiationSensorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKZofHumiditySensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationHumiditySensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HumiditySensorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MethodofFailure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionOfFailure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseofFailure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailedParts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingCableDatas", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatingCableDatas");
        }
    }
}
