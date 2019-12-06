using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HousingType",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CounterFines",
                table: "Sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CurrentBool",
                table: "Sensors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentInt",
                table: "Sensors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentString",
                table: "Sensors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Flag",
                table: "Sensors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    HousingType = table.Column<string>(nullable: true),
                    EcoType = table.Column<string>(nullable: true),
                    SizeFine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PlaceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_PlaceType_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Place_PlaceTypeId",
                table: "Place",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_UserId",
                table: "Place",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropColumn(
                name: "CounterFines",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "CurrentBool",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "CurrentInt",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "CurrentString",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Sensors");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HousingType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
