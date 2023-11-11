using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Transient
{
    public partial class updatetransientdocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransientDocuments_TransientsId",
                table: "TransientDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_TransientDocuments_TransientsId",
                table: "TransientDocuments",
                column: "TransientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransientDocuments_TransientsId",
                table: "TransientDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_TransientDocuments_TransientsId",
                table: "TransientDocuments",
                column: "TransientsId",
                unique: true);
        }
    }
}
