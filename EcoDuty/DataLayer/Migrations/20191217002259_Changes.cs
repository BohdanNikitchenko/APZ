using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines");

            migrationBuilder.AddColumn<int>(
                name: "SizeFine",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Fines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "SizeFine",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Fines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Sensors_SensorId",
                table: "Fines",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
