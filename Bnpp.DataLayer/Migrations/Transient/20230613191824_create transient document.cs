using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Transient
{
    public partial class createtransientdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransientDocuments",
                columns: table => new
                {
                    TransientDocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransientsId = table.Column<int>(type: "int", nullable: false),
                    TransientDocumentsImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransientDocuments", x => x.TransientDocumentsId);
                    table.ForeignKey(
                        name: "FK_TransientDocuments_Transients_TransientsId",
                        column: x => x.TransientsId,
                        principalTable: "Transients",
                        principalColumn: "TransientsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransientDocuments_TransientsId",
                table: "TransientDocuments",
                column: "TransientsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransientDocuments");
        }
    }
}
