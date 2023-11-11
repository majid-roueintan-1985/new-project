﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations.Chemistry
{
    public partial class Updatechemistrytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deviation",
                table: "ChemistryTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deviation",
                table: "ChemistryTable",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}