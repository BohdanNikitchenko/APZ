using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FineChange_FineTypeRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_FineTypes_FineTypeId",
                table: "Fines");

            migrationBuilder.DropTable(
                name: "FineTypes");

            migrationBuilder.DropIndex(
                name: "IX_Fines_FineTypeId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "FineTypeId",
                table: "Fines");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Fines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Fines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicId",
                table: "Fines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fines_PlaceId",
                table: "Fines",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_SensorId",
                table: "Fines",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_TechnicId",
                table: "Fines",
                column: "TechnicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Places_PlaceId",
                table: "Fines",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Technics_TechnicId",
                table: "Fines",
                column: "TechnicId",
                principalTable: "Technics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Places_PlaceId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Technics_TechnicId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_PlaceId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_SensorId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_TechnicId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "TechnicId",
                table: "Fines");

            migrationBuilder.AddColumn<int>(
                name: "FineTypeId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FineTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fines_FineTypeId",
                table: "Fines",
                column: "FineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_FineTypes_FineTypeId",
                table: "Fines",
                column: "FineTypeId",
                principalTable: "FineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
