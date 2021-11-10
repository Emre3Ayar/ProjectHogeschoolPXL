using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeschoolPXL.Migrations
{
    public partial class Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademieJaren",
                columns: table => new
                {
                    AcademieJaarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademieJaren", x => x.AcademieJaarId);
                });

            migrationBuilder.CreateTable(
                name: "Handboeken",
                columns: table => new
                {
                    HandboekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    KostPrijs = table.Column<double>(nullable: false),
                    UitgifteDatum = table.Column<DateTime>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handboeken", x => x.HandboekId);
                });

            migrationBuilder.CreateTable(
                name: "Vakken",
                columns: table => new
                {
                    VakId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VakNaam = table.Column<string>(nullable: false),
                    StudiePunten = table.Column<double>(nullable: false),
                    HandboekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakken", x => x.VakId);
                    table.ForeignKey(
                        name: "FK_Vakken_Handboeken_HandboekId",
                        column: x => x.HandboekId,
                        principalTable: "Handboeken",
                        principalColumn: "HandboekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VakLectors",
                columns: table => new
                {
                    VakLectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectorId = table.Column<int>(nullable: false),
                    VakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VakLectors", x => x.VakLectorId);
                    table.ForeignKey(
                        name: "FK_VakLectors_Lectors_LectorId",
                        column: x => x.LectorId,
                        principalTable: "Lectors",
                        principalColumn: "LectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VakLectors_Vakken_VakId",
                        column: x => x.VakId,
                        principalTable: "Vakken",
                        principalColumn: "VakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    InschrijvingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    VakLectorId = table.Column<int>(nullable: true),
                    AcademieJaarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.InschrijvingId);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_AcademieJaren_AcademieJaarId",
                        column: x => x.AcademieJaarId,
                        principalTable: "AcademieJaren",
                        principalColumn: "AcademieJaarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_VakLectors_VakLectorId",
                        column: x => x.VakLectorId,
                        principalTable: "VakLectors",
                        principalColumn: "VakLectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_AcademieJaarId",
                table: "Inschrijvingen",
                column: "AcademieJaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_StudentId",
                table: "Inschrijvingen",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_VakLectorId",
                table: "Inschrijvingen",
                column: "VakLectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vakken_HandboekId",
                table: "Vakken",
                column: "HandboekId");

            migrationBuilder.CreateIndex(
                name: "IX_VakLectors_LectorId",
                table: "VakLectors",
                column: "LectorId");

            migrationBuilder.CreateIndex(
                name: "IX_VakLectors_VakId",
                table: "VakLectors",
                column: "VakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "AcademieJaren");

            migrationBuilder.DropTable(
                name: "VakLectors");

            migrationBuilder.DropTable(
                name: "Vakken");

            migrationBuilder.DropTable(
                name: "Handboeken");
        }
    }
}
