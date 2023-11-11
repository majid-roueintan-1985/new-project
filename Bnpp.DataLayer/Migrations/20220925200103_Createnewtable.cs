using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class Createnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_State_ChangeState_ChangeStateId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_ChangeStateId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "ChangeStateId",
                table: "State");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "State",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StateOfChangeState",
                columns: table => new
                {
                    SG_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeStateId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOfChangeState", x => x.SG_Id);
                    table.ForeignKey(
                        name: "FK_StateOfChangeState_ChangeState_ChangeStateId",
                        column: x => x.ChangeStateId,
                        principalTable: "ChangeState",
                        principalColumn: "ChangeStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateOfChangeState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StateOfChangeState_ChangeStateId",
                table: "StateOfChangeState",
                column: "ChangeStateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateOfChangeState_StateId",
                table: "StateOfChangeState",
                column: "StateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateOfChangeState");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "State");

            migrationBuilder.AddColumn<int>(
                name: "ChangeStateId",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_State_ChangeStateId",
                table: "State",
                column: "ChangeStateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_State_ChangeState_ChangeStateId",
                table: "State",
                column: "ChangeStateId",
                principalTable: "ChangeState",
                principalColumn: "ChangeStateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
