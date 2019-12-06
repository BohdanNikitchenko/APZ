using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PlaceType");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Place",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Place");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PlaceType",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
