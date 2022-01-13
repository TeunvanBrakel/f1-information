using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace f1_information_backend.Migrations
{
    public partial class banningAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DriverPicked = table.Column<string>(type: "text", nullable: true),
                    RaceGuess = table.Column<string>(type: "text", nullable: true),
                    QualyGuess = table.Column<string>(type: "text", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Circuit = table.Column<string>(type: "text", nullable: true),
                    RaceNumber = table.Column<int>(type: "int", nullable: false),
                    RaceName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DriverFinished = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NumberOfRaces = table.Column<int>(type: "int", nullable: false),
                    DriverStandings = table.Column<string>(type: "text", nullable: true),
                    ConstructorStandings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(type: "text", nullable: true),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PassWord = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    GameSettingsId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    Reports = table.Column<int>(type: "int", nullable: false),
                    Banned = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_GameSettings_GameSettingsId",
                        column: x => x.GameSettingsId,
                        principalTable: "GameSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceResult",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceResult", x => new { x.RaceId, x.ResultId });
                    table.ForeignKey(
                        name: "FK_RaceResult_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceResult_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceSeasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceSeasons", x => new { x.SeasonId, x.RaceId });
                    table.ForeignKey(
                        name: "FK_RaceSeasons_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<string>(type: "text", nullable: true),
                    GivenName = table.Column<string>(type: "text", nullable: true),
                    FamilyName = table.Column<string>(type: "text", nullable: true),
                    PermanentNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CurrentTeam = table.Column<string>(type: "text", nullable: true),
                    CurrentPoints = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    PolePositions = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_Id",
                        column: x => x.Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceFavorites",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFavorites", x => new { x.RaceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RaceFavorites_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverFavorites",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverFavorites", x => new { x.DriverId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DriverFavorites_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverResult",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    ResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverResult", x => new { x.DriverId, x.ResultId });
                    table.ForeignKey(
                        name: "FK_DriverResult_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverResult_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceDrivers",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDrivers", x => new { x.RaceId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_RaceDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceDrivers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverFavorites_UserId",
                table: "DriverFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverResult_ResultId",
                table: "DriverResult",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDrivers_DriverId",
                table: "RaceDrivers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceFavorites_UserId",
                table: "RaceFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResult_ResultId",
                table: "RaceResult",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceSeasons_RaceId",
                table: "RaceSeasons",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GameSettingsId",
                table: "Users",
                column: "GameSettingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverFavorites");

            migrationBuilder.DropTable(
                name: "DriverResult");

            migrationBuilder.DropTable(
                name: "RaceDrivers");

            migrationBuilder.DropTable(
                name: "RaceFavorites");

            migrationBuilder.DropTable(
                name: "RaceResult");

            migrationBuilder.DropTable(
                name: "RaceSeasons");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "GameSettings");
        }
    }
}
