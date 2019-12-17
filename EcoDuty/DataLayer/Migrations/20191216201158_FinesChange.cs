using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FinesChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Places_PlaceId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Technics_TechnicId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Users_UserId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_PlaceId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_TechnicId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_UserId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "TechnicId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Fines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Fines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicId",
                table: "Fines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fines_PlaceId",
                table: "Fines",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_TechnicId",
                table: "Fines",
                column: "TechnicId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_UserId",
                table: "Fines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Places_PlaceId",
                table: "Fines",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Technics_TechnicId",
                table: "Fines",
                column: "TechnicId",
                principalTable: "Technics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Users_UserId",
                table: "Fines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
