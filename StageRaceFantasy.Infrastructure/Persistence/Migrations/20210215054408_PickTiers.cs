using Microsoft.EntityFrameworkCore.Migrations;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    public partial class PickTiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceEntries_Owners_OwnerId",
                table: "RaceEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceEntries_Races_RaceId",
                table: "RaceEntries");

            migrationBuilder.DropTable(
                name: "RacePickDrivers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RaceEntries_OwnerId_RaceId",
                table: "RaceEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceEntries",
                table: "RaceEntries");

            migrationBuilder.RenameTable(
                name: "RaceEntries",
                newName: "RacePicks");

            migrationBuilder.RenameIndex(
                name: "IX_RaceEntries_RaceId",
                table: "RacePicks",
                newName: "IX_RacePicks_RaceId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DriverRaceEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RacePickId",
                table: "DriverRaceEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RacePicks_OwnerId_RaceId",
                table: "RacePicks",
                columns: new[] { "OwnerId", "RaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RacePicks",
                table: "RacePicks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRaceEntries_RacePickId",
                table: "DriverRaceEntries",
                column: "RacePickId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceEntries_RacePicks_RacePickId",
                table: "DriverRaceEntries",
                column: "RacePickId",
                principalTable: "RacePicks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RacePicks_Owners_OwnerId",
                table: "RacePicks",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacePicks_Races_RaceId",
                table: "RacePicks",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceEntries_RacePicks_RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_RacePicks_Owners_OwnerId",
                table: "RacePicks");

            migrationBuilder.DropForeignKey(
                name: "FK_RacePicks_Races_RaceId",
                table: "RacePicks");

            migrationBuilder.DropIndex(
                name: "IX_DriverRaceEntries_RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RacePicks_OwnerId_RaceId",
                table: "RacePicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RacePicks",
                table: "RacePicks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DriverRaceEntries");

            migrationBuilder.DropColumn(
                name: "RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.RenameTable(
                name: "RacePicks",
                newName: "RaceEntries");

            migrationBuilder.RenameIndex(
                name: "IX_RacePicks_RaceId",
                table: "RaceEntries",
                newName: "IX_RaceEntries_RaceId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RaceEntries_OwnerId_RaceId",
                table: "RaceEntries",
                columns: new[] { "OwnerId", "RaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceEntries",
                table: "RaceEntries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RacePickDrivers",
                columns: table => new
                {
                    RacePickId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacePickDrivers", x => new { x.RacePickId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_RacePickDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacePickDrivers_RaceEntries_RacePickId",
                        column: x => x.RacePickId,
                        principalTable: "RaceEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacePickDrivers_DriverId",
                table: "RacePickDrivers",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceEntries_Owners_OwnerId",
                table: "RaceEntries",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceEntries_Races_RaceId",
                table: "RaceEntries",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
