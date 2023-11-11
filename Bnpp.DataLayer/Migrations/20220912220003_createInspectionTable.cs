using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class createInspectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionPrograms",
                columns: table => new
                {
                    InspectionProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScopeofInspection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodofInspection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryofWeldedjoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPrograms", x => x.InspectionProgramId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionPrograms");
        }
    }
}
