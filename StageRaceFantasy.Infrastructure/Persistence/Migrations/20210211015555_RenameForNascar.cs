using Microsoft.EntityFrameworkCore.Migrations;

namespace StageRaceFantasy.Infrastructure.Persistence.Migrations
{
    public partial class RenameForNascar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyTeamRaceEntryRider");

            migrationBuilder.DropTable(
                name: "RaceStages");

            migrationBuilder.DropTable(
                name: "RiderRaceEntries");

            migrationBuilder.DropTable(
                name: "FantasyTeamRaceEntries");

            migrationBuilder.DropTable(
                name: "Riders");

            migrationBuilder.DropTable(
                name: "FantasyTeams");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverRaceEntries",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    CarNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRaceEntries", x => new { x.RaceId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_DriverRaceEntries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverRaceEntries_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEntries", x => x.Id);
                    table.UniqueConstraint("AK_RaceEntries_OwnerId_RaceId", x => new { x.OwnerId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RaceEntries_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceEntries_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceEntryDriver",
                columns: table => new
                {
                    RaceEntryId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEntryDriver", x => new { x.RaceEntryId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_RaceEntryDriver_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceEntryDriver_RaceEntries_RaceEntryId",
                        column: x => x.RaceEntryId,
                        principalTable: "RaceEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverRaceEntries_DriverId",
                table: "DriverRaceEntries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceEntries_RaceId",
                table: "RaceEntries",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceEntryDriver_DriverId",
                table: "RaceEntryDriver",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverRaceEntries");

            migrationBuilder.DropTable(
                name: "RaceEntryDriver");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "RaceEntries");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.CreateTable(
                name: "FantasyTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceStages_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FantasyTeamRaceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FantasyTeamId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyTeamRaceEntries", x => x.Id);
                    table.UniqueConstraint("AK_FantasyTeamRaceEntries_FantasyTeamId_RaceId", x => new { x.FantasyTeamId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_FantasyTeamRaceEntries_FantasyTeams_FantasyTeamId",
                        column: x => x.FantasyTeamId,
                        principalTable: "FantasyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyTeamRaceEntries_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiderRaceEntries",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false),
                    BibNumber = table.Column<int>(type: "int", nullable: false),
                    StarValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderRaceEntries", x => new { x.RaceId, x.RiderId });
                    table.ForeignKey(
                        name: "FK_RiderRaceEntries_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiderRaceEntries_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyTeamRaceEntryRider",
                columns: table => new
                {
                    FantasyTeamRaceEntryId = table.Column<int>(type: "int", nullable: false),
                    RiderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyTeamRaceEntryRider", x => new { x.FantasyTeamRaceEntryId, x.RiderId });
                    table.ForeignKey(
                        name: "FK_FantasyTeamRaceEntryRider_FantasyTeamRaceEntries_FantasyTeamRaceEntryId",
                        column: x => x.FantasyTeamRaceEntryId,
                        principalTable: "FantasyTeamRaceEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyTeamRaceEntryRider_Riders_RiderId",
                        column: x => x.RiderId,
                        principalTable: "Riders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeamRaceEntries_RaceId",
                table: "FantasyTeamRaceEntries",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyTeamRaceEntryRider_RiderId",
                table: "FantasyTeamRaceEntryRider",
                column: "RiderId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceStages_RaceId",
                table: "RaceStages",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RiderRaceEntries_RiderId",
                table: "RiderRaceEntries",
                column: "RiderId");
        }
    }
}
