using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    public partial class AddEntryTier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tier",
                table: "DriverRaceEntries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tier",
                table: "DriverRaceEntries");
        }
    }
}
