﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bnpp.DataLayer.Migrations
{
    public partial class CreateElectromotorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electromotors",
                columns: table => new
                {
                    ElectromotorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Station1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Station2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Azk = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AzkStruct = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CableImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BasicImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electromotors", x => x.ElectromotorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Electromotors");
        }
    }
}
