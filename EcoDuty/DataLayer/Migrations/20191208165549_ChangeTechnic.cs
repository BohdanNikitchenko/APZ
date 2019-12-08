using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangeTechnic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutoNumber",
                table: "Technics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EngineVolume",
                table: "Technics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfCarManufacture",
                table: "Technics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoNumber",
                table: "Technics");

            migrationBuilder.DropColumn(
                name: "EngineVolume",
                table: "Technics");

            migrationBuilder.DropColumn(
                name: "YearOfCarManufacture",
                table: "Technics");
        }
    }
}
