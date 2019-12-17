using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddUnique1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AutoNumber",
                table: "Technics",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Fines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technics_AutoNumber",
                table: "Technics",
                column: "AutoNumber",
                unique: true,
                filter: "[AutoNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Places_Address",
                table: "Places",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Technics_AutoNumber",
                table: "Technics");

            migrationBuilder.DropIndex(
                name: "IX_Places_Address",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fines");

            migrationBuilder.AlterColumn<string>(
                name: "AutoNumber",
                table: "Technics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
