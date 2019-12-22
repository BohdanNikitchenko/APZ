using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class fixUniquePlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Places_Address",
                table: "Places");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_Address",
                table: "Places",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");
        }
    }
}
