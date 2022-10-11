using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht6.Migrations
{
    public partial class MigrationNew4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "aantalLikes",
                table: "Attractie",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aantalLikes",
                table: "Attractie");
        }
    }
}
