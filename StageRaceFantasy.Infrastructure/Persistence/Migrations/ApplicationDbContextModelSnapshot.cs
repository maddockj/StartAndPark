﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartAndPark.Infrastructure.Persistence;

namespace StartAndPark.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StartAndPark.Domain.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NascarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Owner", b =>
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

            modelBuilder.Entity("StartAndPark.Domain.Entities.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NascarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("WinningDriverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.HasIndex("WinningDriverId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RaceEntry", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("CarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RaceId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverRaceEntries");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RacePick", b =>
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

            modelBuilder.Entity("StartAndPark.Domain.Entities.RacePickDrivers", b =>
                {
                    b.Property<int>("RacePickId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("RacePickId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("RacePickDrivers");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NascarId")
                        .HasColumnType("int");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Race", b =>
                {
                    b.HasOne("StartAndPark.Domain.Entities.Track", "Track")
                        .WithMany("Races")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartAndPark.Domain.Entities.Driver", "WinningDriver")
                        .WithMany()
                        .HasForeignKey("WinningDriverId");

                    b.Navigation("Track");

                    b.Navigation("WinningDriver");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RaceEntry", b =>
                {
                    b.HasOne("StartAndPark.Domain.Entities.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartAndPark.Domain.Entities.Race", "Race")
                        .WithMany("DriverEntries")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RacePick", b =>
                {
                    b.HasOne("StartAndPark.Domain.Entities.Owner", "Owner")
                        .WithMany("RaceEntries")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartAndPark.Domain.Entities.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RacePickDrivers", b =>
                {
                    b.HasOne("StartAndPark.Domain.Entities.Driver", "Driver")
                        .WithMany("RaceEntryDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartAndPark.Domain.Entities.RacePick", "RacePick")
                        .WithMany("RacePickDrivers")
                        .HasForeignKey("RacePickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("RacePick");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Driver", b =>
                {
                    b.Navigation("RaceEntryDrivers");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Owner", b =>
                {
                    b.Navigation("RaceEntries");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Race", b =>
                {
                    b.Navigation("DriverEntries");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.RacePick", b =>
                {
                    b.Navigation("RacePickDrivers");
                });

            modelBuilder.Entity("StartAndPark.Domain.Entities.Track", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
