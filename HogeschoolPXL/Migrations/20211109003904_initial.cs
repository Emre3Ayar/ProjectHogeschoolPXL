using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPXL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.GebruikerId);
                });

            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    LectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.LectorId);
                    table.ForeignKey(
                        name: "FK_Lectors_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "GebruikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectors_GebruikerId",
                table: "Lectors",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GebruikerId",
                table: "Students",
                column: "GebruikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
