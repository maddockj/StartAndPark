using Microsoft.EntityFrameworkCore.Migrations;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    public partial class PickTiersCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Dropping unnamed constraint on [dbo].[DriverRaceEntries]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] DROP CONSTRAINT [DF__DriverRaceEn__Id__01142BA1];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Dropping [dbo].[FK_DriverRaceEntries_RacePicks_RacePickId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] DROP CONSTRAINT [FK_DriverRaceEntries_RacePicks_RacePickId];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Dropping [dbo].[FK_DriverRaceEntries_Drivers_DriverId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] DROP CONSTRAINT [FK_DriverRaceEntries_Drivers_DriverId];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Dropping [dbo].[FK_DriverRaceEntries_Races_RaceId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] DROP CONSTRAINT [FK_DriverRaceEntries_Races_RaceId];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Starting rebuilding table [dbo].[DriverRaceEntries]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_DriverRaceEntries] (
    [DriverId]   INT            NOT NULL,
    [RaceId]     INT            NOT NULL,
    [CarNumber]  NVARCHAR (MAX) NULL,
    [Tier]       NVARCHAR (MAX) NULL,
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RacePickId] INT            NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_DriverRaceEntries1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[DriverRaceEntries])
    BEGIN
        -- SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DriverRaceEntries] ON;
        INSERT INTO [dbo].[tmp_ms_xx_DriverRaceEntries] ([DriverId], [RaceId], [CarNumber], [Tier], [RacePickId])
        SELECT   [DriverId],
                 [RaceId],
                 [CarNumber],
                 [Tier],
                 [RacePickId]
        FROM     [dbo].[DriverRaceEntries]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_DriverRaceEntries] OFF;
    END

DROP TABLE [dbo].[DriverRaceEntries];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_DriverRaceEntries]', N'DriverRaceEntries';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_DriverRaceEntries1]', N'PK_DriverRaceEntries', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[DriverRaceEntries].[IX_DriverRaceEntries_DriverId]...';


GO
CREATE NONCLUSTERED INDEX [IX_DriverRaceEntries_DriverId]
    ON [dbo].[DriverRaceEntries]([DriverId] ASC);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[DriverRaceEntries].[IX_DriverRaceEntries_RacePickId]...';


GO
CREATE NONCLUSTERED INDEX [IX_DriverRaceEntries_RacePickId]
    ON [dbo].[DriverRaceEntries]([RacePickId] ASC);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_DriverRaceEntries_RacePicks_RacePickId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] WITH NOCHECK
    ADD CONSTRAINT [FK_DriverRaceEntries_RacePicks_RacePickId] FOREIGN KEY ([RacePickId]) REFERENCES [dbo].[RacePicks] ([Id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_DriverRaceEntries_Drivers_DriverId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] WITH NOCHECK
    ADD CONSTRAINT [FK_DriverRaceEntries_Drivers_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [dbo].[Drivers] ([Id]) ON DELETE CASCADE;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating [dbo].[FK_DriverRaceEntries_Races_RaceId]...';


GO
ALTER TABLE [dbo].[DriverRaceEntries] WITH NOCHECK
    ADD CONSTRAINT [FK_DriverRaceEntries_Races_RaceId] FOREIGN KEY ([RaceId]) REFERENCES [dbo].[Races] ([Id]) ON DELETE CASCADE;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Checking existing data against newly created constraints';



GO
ALTER TABLE [dbo].[DriverRaceEntries] WITH CHECK CHECK CONSTRAINT [FK_DriverRaceEntries_RacePicks_RacePickId];

ALTER TABLE [dbo].[DriverRaceEntries] WITH CHECK CHECK CONSTRAINT [FK_DriverRaceEntries_Drivers_DriverId];

ALTER TABLE [dbo].[DriverRaceEntries] WITH CHECK CHECK CONSTRAINT [FK_DriverRaceEntries_Races_RaceId];


GO
PRINT N'Update complete.';


GO
");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceEntries_Drivers_DriverId",
                table: "DriverRaceEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceEntries_RacePicks_RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverRaceEntries_Races_RaceId",
                table: "DriverRaceEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverRaceEntries",
                table: "DriverRaceEntries");

            migrationBuilder.DropIndex(
                name: "IX_DriverRaceEntries_RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.DropColumn(
                name: "RacePickId",
                table: "DriverRaceEntries");

            migrationBuilder.RenameTable(
                name: "DriverRaceEntries",
                newName: "RaceEntries");

            migrationBuilder.RenameIndex(
                name: "IX_DriverRaceEntries_DriverId",
                table: "RaceEntries",
                newName: "IX_RaceEntries_DriverId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "RaceEntries",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RaceEntries_RaceId_DriverId",
                table: "RaceEntries",
                columns: new[] { "RaceId", "DriverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceEntries",
                table: "RaceEntries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RaceEntryRacePick",
                columns: table => new
                {
                    RaceEntriesId = table.Column<int>(type: "int", nullable: false),
                    RacePicksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEntryRacePick", x => new { x.RaceEntriesId, x.RacePicksId });
                    table.ForeignKey(
                        name: "FK_RaceEntryRacePick_RaceEntries_RaceEntriesId",
                        column: x => x.RaceEntriesId,
                        principalTable: "RaceEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceEntryRacePick_RacePicks_RacePicksId",
                        column: x => x.RacePicksId,
                        principalTable: "RacePicks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceEntryRacePick_RacePicksId",
                table: "RaceEntryRacePick",
                column: "RacePicksId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceEntries_Drivers_DriverId",
                table: "RaceEntries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceEntries_Races_RaceId",
                table: "RaceEntries",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceEntries_Drivers_DriverId",
                table: "RaceEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceEntries_Races_RaceId",
                table: "RaceEntries");

            migrationBuilder.DropTable(
                name: "RaceEntryRacePick");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RaceEntries_RaceId_DriverId",
                table: "RaceEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceEntries",
                table: "RaceEntries");

            migrationBuilder.RenameTable(
                name: "RaceEntries",
                newName: "DriverRaceEntries");

            migrationBuilder.RenameIndex(
                name: "IX_RaceEntries_DriverId",
                table: "DriverRaceEntries",
                newName: "IX_DriverRaceEntries_DriverId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "DriverRaceEntries",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RacePickId",
                table: "DriverRaceEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverRaceEntries",
                table: "DriverRaceEntries",
                columns: new[] { "RaceId", "DriverId" });

            migrationBuilder.CreateIndex(
                name: "IX_DriverRaceEntries_RacePickId",
                table: "DriverRaceEntries",
                column: "RacePickId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceEntries_Drivers_DriverId",
                table: "DriverRaceEntries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceEntries_RacePicks_RacePickId",
                table: "DriverRaceEntries",
                column: "RacePickId",
                principalTable: "RacePicks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverRaceEntries_Races_RaceId",
                table: "DriverRaceEntries",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
