using Microsoft.EntityFrameworkCore.Migrations;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    public partial class Renames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceEntryId", 
                table: "RaceEntryDriver", 
                newName: "RacePickId");

            migrationBuilder.RenameTable(
                name: "RaceEntryDriver", newName: "RacePickDrivers");

            migrationBuilder.RenameIndex(
                name: "IX_RaceEntryDriver_DriverId",
                newName: "IX_RacePickDrivers_DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RacePickId",
                table: "RaceEntryDriver",
                newName: "RaceEntryId");

            migrationBuilder.RenameTable(
                name: "RacePickDrivers", newName: "RaceEntryDriver");

            migrationBuilder.RenameIndex(
                name: "IX_RacePickDrivers_DriverId",
                newName: "IX_RaceEntryDriver_DriverId");
        }
    }
}
