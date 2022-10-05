using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht4Database.Migrations
{
    public partial class oegaboega1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attracties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attracties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GastInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaatstBezochteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coordinaat_X = table.Column<int>(type: "int", nullable: false),
                    coordinaat_Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    probleem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attractieId = table.Column<int>(type: "int", nullable: false),
                    dateTimeBereik_begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attracties_attractieId",
                        column: x => x.attractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false),
                    geboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    begeleidtId = table.Column<int>(type: "int", nullable: true),
                    favorietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasten_Attracties_favorietId",
                        column: x => x.favorietId,
                        principalTable: "Attracties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_begeleidtId",
                        column: x => x.begeleidtId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasten_GastInfo_Id",
                        column: x => x.Id,
                        principalTable: "GastInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_Id",
                        column: x => x.Id,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gastId = table.Column<int>(type: "int", nullable: true),
                    dateTimeBereik_begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_eind = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attractieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Attracties_attractieId",
                        column: x => x.attractieId,
                        principalTable: "Attracties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reserveringen_Gasten_gastId",
                        column: x => x.gastId,
                        principalTable: "Gasten",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medewerker_Coordineert",
                columns: table => new
                {
                    coordinatorenId = table.Column<int>(type: "int", nullable: false),
                    coordineerdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker_Coordineert", x => new { x.coordinatorenId, x.coordineerdId });
                    table.ForeignKey(
                        name: "FK_Medewerker_Coordineert_Medewerkers_coordinatorenId",
                        column: x => x.coordinatorenId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medewerker_Coordineert_Onderhoud_coordineerdId",
                        column: x => x.coordineerdId,
                        principalTable: "Onderhoud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medewerker_Onderhouden",
                columns: table => new
                {
                    onderhoudersId = table.Column<int>(type: "int", nullable: false),
                    onderhoudtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker_Onderhouden", x => new { x.onderhoudersId, x.onderhoudtId });
                    table.ForeignKey(
                        name: "FK_Medewerker_Onderhouden_Medewerkers_onderhoudersId",
                        column: x => x.onderhoudersId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medewerker_Onderhouden_Onderhoud_onderhoudtId",
                        column: x => x.onderhoudtId,
                        principalTable: "Onderhoud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_begeleidtId",
                table: "Gasten",
                column: "begeleidtId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_favorietId",
                table: "Gasten",
                column: "favorietId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_Coordineert_coordineerdId",
                table: "Medewerker_Coordineert",
                column: "coordineerdId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_Onderhouden_onderhoudtId",
                table: "Medewerker_Onderhouden",
                column: "onderhoudtId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_attractieId",
                table: "Onderhoud",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_attractieId",
                table: "Reserveringen",
                column: "attractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_gastId",
                table: "Reserveringen",
                column: "gastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerker_Coordineert");

            migrationBuilder.DropTable(
                name: "Medewerker_Onderhouden");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attracties");

            migrationBuilder.DropTable(
                name: "GastInfo");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
