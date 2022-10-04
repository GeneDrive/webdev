using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht4Database.Migrations
{
    public partial class addedGastEnMedewerkersAttempt14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gasten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasten", x => x.ID);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gasten");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
