using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_PlaceType_PlaceTypeId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Users_UserId",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceType",
                table: "PlaceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.RenameTable(
                name: "PlaceType",
                newName: "PlaceTypes");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameIndex(
                name: "IX_Place_UserId",
                table: "Places",
                newName: "IX_Places_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Place_PlaceTypeId",
                table: "Places",
                newName: "IX_Places_PlaceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceTypes",
                table: "PlaceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceTypes_PlaceTypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceTypes",
                table: "PlaceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "PlaceTypes",
                newName: "PlaceType");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameIndex(
                name: "IX_Places_UserId",
                table: "Place",
                newName: "IX_Place_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_PlaceTypeId",
                table: "Place",
                newName: "IX_Place_PlaceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceType",
                table: "PlaceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_PlaceType_PlaceTypeId",
                table: "Place",
                column: "PlaceTypeId",
                principalTable: "PlaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Users_UserId",
                table: "Place",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
