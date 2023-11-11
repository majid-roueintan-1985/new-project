using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class createreportcabletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CableReports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableIDGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datefrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingDesignLifeTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeofOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureDetctionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FailedParts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateMaintenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMaintenance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeofMaintenancework = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeofTests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableReports", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CableReports");
        }
    }
}
