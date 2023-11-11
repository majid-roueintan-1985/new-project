using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class hhhhhhhhhhhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateOfChangeState");

            migrationBuilder.CreateTable(
                name: "ChangingInState",
                columns: table => new
                {
                    SG_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeStateId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangingInState", x => x.SG_Id);
                    table.ForeignKey(
                        name: "FK_ChangingInState_ChangeState_ChangeStateId",
                        column: x => x.ChangeStateId,
                        principalTable: "ChangeState",
                        principalColumn: "ChangeStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangingInState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangingInState_ChangeStateId",
                table: "ChangingInState",
                column: "ChangeStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangingInState_StateId",
                table: "ChangingInState",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangingInState");

            migrationBuilder.CreateTable(
                name: "StateOfChangeState",
                columns: table => new
                {
                    SGu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eeeeee = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOfChangeState", x => x.SGu_Id);
                });
        }
    }
}
