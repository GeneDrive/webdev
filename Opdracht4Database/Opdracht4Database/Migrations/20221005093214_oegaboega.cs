using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht4Database.Migrations
{
    public partial class oegaboega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GastInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaatstBezochteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coordinaat_X = table.Column<int>(type: "int", nullable: false),
                    coordinaat_Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    probleem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    attractieID = table.Column<int>(type: "int", nullable: false),
                    dateTimeBereik_begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_eind = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Attractie_attractieID",
                        column: x => x.attractieID,
                        principalTable: "Attractie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false),
                    geboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    begeleidtID = table.Column<int>(type: "int", nullable: true),
                    favorietID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gasten_Attractie_favorietID",
                        column: x => x.favorietID,
                        principalTable: "Attractie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Gasten_Gasten_begeleidtID",
                        column: x => x.begeleidtID,
                        principalTable: "Gasten",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Gasten_GastInfo_ID",
                        column: x => x.ID,
                        principalTable: "GastInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gasten_Gebruikers_ID",
                        column: x => x.ID,
                        principalTable: "Gebruikers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Gebruikers_ID",
                        column: x => x.ID,
                        principalTable: "Gebruikers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gastID = table.Column<int>(type: "int", nullable: true),
                    dateTimeBereik_begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateTimeBereik_eind = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attractieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservering_Attractie_attractieID",
                        column: x => x.attractieID,
                        principalTable: "Attractie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Reservering_Gasten_gastID",
                        column: x => x.gastID,
                        principalTable: "Gasten",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud",
                columns: table => new
                {
                    onderhoudersID = table.Column<int>(type: "int", nullable: false),
                    onderhoudtID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud", x => new { x.onderhoudersID, x.onderhoudtID });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Medewerkers_onderhoudersID",
                        column: x => x.onderhoudersID,
                        principalTable: "Medewerkers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud_Onderhoud_onderhoudtID",
                        column: x => x.onderhoudtID,
                        principalTable: "Onderhoud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerOnderhoud1",
                columns: table => new
                {
                    coordinatorenID = table.Column<int>(type: "int", nullable: false),
                    coordineerdID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerOnderhoud1", x => new { x.coordinatorenID, x.coordineerdID });
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Medewerkers_coordinatorenID",
                        column: x => x.coordinatorenID,
                        principalTable: "Medewerkers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerOnderhoud1_Onderhoud_coordineerdID",
                        column: x => x.coordineerdID,
                        principalTable: "Onderhoud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_begeleidtID",
                table: "Gasten",
                column: "begeleidtID");

            migrationBuilder.CreateIndex(
                name: "IX_Gasten_favorietID",
                table: "Gasten",
                column: "favorietID");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud_onderhoudtID",
                table: "MedewerkerOnderhoud",
                column: "onderhoudtID");

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerOnderhoud1_coordineerdID",
                table: "MedewerkerOnderhoud1",
                column: "coordineerdID");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_attractieID",
                table: "Onderhoud",
                column: "attractieID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_attractieID",
                table: "Reservering",
                column: "attractieID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_gastID",
                table: "Reservering",
                column: "gastID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud");

            migrationBuilder.DropTable(
                name: "MedewerkerOnderhoud1");

            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Attractie");

            migrationBuilder.DropTable(
                name: "GastInfo");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
