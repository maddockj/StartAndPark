﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartAndPark.Infrastructure.Persistence;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210211015555_RenameForNascar")]
    partial class RenameForNascar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.DriverRaceEntry", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("CarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RaceId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverRaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FantasyTeamSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.RaceEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("OwnerId", "RaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.RaceEntryDriver", b =>
                {
                    b.Property<int>("RaceEntryId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("RaceEntryId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("RaceEntryDriver");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.DriverRaceEntry", b =>
                {
                    b.HasOne("StageRaceFantasy.Domain.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Domain.Entities.Race", "Race")
                        .WithMany("DriverEntries")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.RaceEntry", b =>
                {
                    b.HasOne("StageRaceFantasy.Domain.Entities.Owner", "FantasyTeam")
                        .WithMany("RaceEntries")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Domain.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyTeam");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.RaceEntryDriver", b =>
                {
                    b.HasOne("StageRaceFantasy.Domain.Entities.Driver", "Driver")
                        .WithMany("RaceEntryDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StageRaceFantasy.Domain.Entities.RaceEntry", "RaceEntry")
                        .WithMany("RaceEntryDrivers")
                        .HasForeignKey("RaceEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("RaceEntry");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Driver", b =>
                {
                    b.Navigation("RaceEntryDrivers");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Owner", b =>
                {
                    b.Navigation("RaceEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.Race", b =>
                {
                    b.Navigation("DriverEntries");
                });

            modelBuilder.Entity("StageRaceFantasy.Domain.Entities.RaceEntry", b =>
                {
                    b.Navigation("RaceEntryDrivers");
                });
#pragma warning restore 612, 618
        }
    }
}
