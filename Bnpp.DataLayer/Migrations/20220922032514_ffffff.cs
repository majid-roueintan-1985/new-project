using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class ffffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operationals_OperationalType_OperationalTypeTypeId",
                table: "Operationals");

            migrationBuilder.DropIndex(
                name: "IX_Operationals_OperationalTypeTypeId",
                table: "Operationals");

            migrationBuilder.DropColumn(
                name: "OperationalTypeTypeId",
                table: "Operationals");

           

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibleUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationalOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventConsequences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeHeatPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeElectricalPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeEffectiveWorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforePressureWater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforePressureinFirstCircuit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforePressureinSecondCircuit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeforeVaccuminCondensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterHeatPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterElectricalPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterEffectiveWorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterPressureWater = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterPressureinFirstCircuit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterPressureinSecondCircuit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfterVaccuminCondensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventsId);
                });

           

           

            migrationBuilder.CreateIndex(
                name: "IX_Operationals_TypeId",
                table: "Operationals",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operationals_OperationalType_TypeId",
                table: "Operationals",
                column: "TypeId",
                principalTable: "OperationalType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operationals_OperationalType_TypeId",
                table: "Operationals");

            

            migrationBuilder.DropTable(
                name: "Events");

           

            migrationBuilder.DropIndex(
                name: "IX_Operationals_TypeId",
                table: "Operationals");

            migrationBuilder.AddColumn<int>(
                name: "OperationalTypeTypeId",
                table: "Operationals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operationals_OperationalTypeTypeId",
                table: "Operationals",
                column: "OperationalTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operationals_OperationalType_OperationalTypeTypeId",
                table: "Operationals",
                column: "OperationalTypeTypeId",
                principalTable: "OperationalType",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
