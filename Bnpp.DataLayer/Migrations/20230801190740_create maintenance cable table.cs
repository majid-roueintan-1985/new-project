using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class createmaintenancecabletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceCables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableIDGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTimeMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisualResultMaintenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionMaintenanceReasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachActNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeofMaintenancework = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachActImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachActFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptanceCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCables", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceCables");
        }
    }
}
