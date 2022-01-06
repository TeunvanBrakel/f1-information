﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using f1_information_backend.Database;

namespace f1_information_backend.Migrations
{
    [DbContext(typeof(Database.DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("f1_information_backend.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPoints")
                        .HasColumnType("int");

                    b.Property<string>("CurrentTeam")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FamilyName")
                        .HasColumnType("text");

                    b.Property<string>("GivenName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<int>("PermanentNumber")
                        .HasColumnType("int");

                    b.Property<int>("PolePositions")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<string>("driverId")
                        .HasColumnType("text");

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("f1_information_backend.Models.DriverFavorites", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DriverId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DriverFavorites");
                });

            modelBuilder.Entity("f1_information_backend.Models.DriverResult", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("ResultId")
                        .HasColumnType("int");

                    b.HasKey("DriverId", "ResultId");

                    b.HasIndex("ResultId");

                    b.ToTable("DriverResult");
                });

            modelBuilder.Entity("f1_information_backend.Models.GameSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DriverPicked")
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("QualyGuess")
                        .HasColumnType("text");

                    b.Property<string>("RaceGuess")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameSettings");
                });

            modelBuilder.Entity("f1_information_backend.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Circuit")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("RaceName")
                        .HasColumnType("text");

                    b.Property<int>("RaceNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceDrivers", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("RaceDrivers");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceFavorites", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RaceFavorites");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceResult", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("ResultId")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "ResultId");

                    b.HasIndex("ResultId");

                    b.ToTable("RaceResult");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceSeason", b =>
                {
                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("SeasonId", "RaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("RaceSeasons");
                });

            modelBuilder.Entity("f1_information_backend.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriverFinished")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("f1_information_backend.Models.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConstructorStandings")
                        .HasColumnType("text");

                    b.Property<string>("DriverStandings")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfRaces")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("f1_information_backend.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("text");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("f1_information_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("GameSettingsId")
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameSettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("f1_information_backend.Models.Driver", b =>
                {
                    b.HasOne("f1_information_backend.Models.Team", "Team")
                        .WithMany("currentDrivers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("f1_information_backend.Models.DriverFavorites", b =>
                {
                    b.HasOne("f1_information_backend.Models.Driver", "Driver")
                        .WithMany("FavoritesUser")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.User", "User")
                        .WithMany("DriverFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("f1_information_backend.Models.DriverResult", b =>
                {
                    b.HasOne("f1_information_backend.Models.Driver", "Driver")
                        .WithMany("Results")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.Result", "Result")
                        .WithMany("Drivers")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceDrivers", b =>
                {
                    b.HasOne("f1_information_backend.Models.Driver", "Driver")
                        .WithMany("Races")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.Race", "Race")
                        .WithMany("Drivers")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceFavorites", b =>
                {
                    b.HasOne("f1_information_backend.Models.Race", "Race")
                        .WithMany("RaceFavoritesUser")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.User", "User")
                        .WithMany("RaceFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceResult", b =>
                {
                    b.HasOne("f1_information_backend.Models.Race", "Race")
                        .WithMany("Results")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.Result", "Result")
                        .WithMany("Races")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("f1_information_backend.Models.RaceSeason", b =>
                {
                    b.HasOne("f1_information_backend.Models.Race", "Race")
                        .WithMany("Seasons")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("f1_information_backend.Models.Season", "Season")
                        .WithMany("Races")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("f1_information_backend.Models.User", b =>
                {
                    b.HasOne("f1_information_backend.Models.GameSettings", "GameSettings")
                        .WithMany("User")
                        .HasForeignKey("GameSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSettings");
                });

            modelBuilder.Entity("f1_information_backend.Models.Driver", b =>
                {
                    b.Navigation("FavoritesUser");

                    b.Navigation("Races");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("f1_information_backend.Models.GameSettings", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("f1_information_backend.Models.Race", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("RaceFavoritesUser");

                    b.Navigation("Results");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("f1_information_backend.Models.Result", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Races");
                });

            modelBuilder.Entity("f1_information_backend.Models.Season", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("f1_information_backend.Models.Team", b =>
                {
                    b.Navigation("currentDrivers");
                });

            modelBuilder.Entity("f1_information_backend.Models.User", b =>
                {
                    b.Navigation("DriverFavorites");

                    b.Navigation("RaceFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
