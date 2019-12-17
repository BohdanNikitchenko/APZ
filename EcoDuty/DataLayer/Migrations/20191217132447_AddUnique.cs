using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Sensors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Passport",
                table: "Users",
                column: "Passport",
                unique: true,
                filter: "[Passport] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SerialNumber",
                table: "Sensors",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Passport",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_SerialNumber",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Sensors");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
