using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class updatedesigntable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccuranceDate",
                table: "Occurances");

            migrationBuilder.DropColumn(
                name: "DesignBasisDate",
                table: "DesignBasis");

            migrationBuilder.AddColumn<string>(
                name: "Dates",
                table: "Occurances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dates",
                table: "DesignBasis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Occurances");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "DesignBasis");

            migrationBuilder.AddColumn<DateTime>(
                name: "OccuranceDate",
                table: "Occurances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DesignBasisDate",
                table: "DesignBasis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
