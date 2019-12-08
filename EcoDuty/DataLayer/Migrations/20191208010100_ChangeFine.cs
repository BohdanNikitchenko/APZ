using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangeFine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeFine",
                table: "FineTypes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeFine",
                table: "Fines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "SizeFine",
                table: "Fines");

            migrationBuilder.AddColumn<int>(
                name: "SizeFine",
                table: "FineTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
