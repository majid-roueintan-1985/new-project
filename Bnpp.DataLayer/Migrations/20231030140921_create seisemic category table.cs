using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class createseisemiccategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeismicCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAndDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorySeismic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MechanicalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeismicCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_SeismicCategory_MechanicalEquipments_MechanicalId",
                        column: x => x.MechanicalId,
                        principalTable: "MechanicalEquipments",
                        principalColumn: "MechanicalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeismicCategory_MechanicalId",
                table: "SeismicCategory",
                column: "MechanicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeismicCategory");
        }
    }
}
