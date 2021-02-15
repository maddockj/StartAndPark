using Microsoft.EntityFrameworkCore.Migrations;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    public partial class Nascar1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "TeamSize",
                table: "Races",
                newName: "Type");

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "Tracks",
                type: "decimal(18,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NascarId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surface",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NascarId",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinningDriverId",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_WinningDriverId",
                table: "Races",
                column: "WinningDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Drivers_WinningDriverId",
                table: "Races",
                column: "WinningDriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Drivers_WinningDriverId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_WinningDriverId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "NascarId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "NascarId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "WinningDriverId",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Races",
                newName: "TeamSize");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Races",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
